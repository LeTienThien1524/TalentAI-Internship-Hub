using AutoMapper;
using MediatR;

using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Auth.DTOs;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Entities.Identity;
using TalentAI.Domain.Entities.System;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler
    : IRequestHandler<LoginCommand, Result<AuthResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;
    private readonly IMapper _mapper;

    public LoginCommandHandler(
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IJwtService jwtService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
        _mapper = mapper;
    }

    public async Task<Result<AuthResponseDto>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        // User
        var user = await _unitOfWork.Users
            .GetByEmailAsync(request.Email);

        if (user is null)
        {
            return Result<AuthResponseDto>.Unauthorized(
                "Email or password is incorrect.");
        }

        if (!user.IsActive)
        {
            return Result<AuthResponseDto>.Forbidden(
                "Account has been disabled.");
        }

        // Password
        if (!_passwordHasher.VerifyPassword(
            request.Password,
            user.PasswordHash))
        {
            return Result<AuthResponseDto>.Unauthorized(
                "Email or password is incorrect.");
        }

        // Roles
        var roles = await _unitOfWork.UserRoles
            .GetRolesByUserIdAsync(user.Id);

        var roleNames = roles
            .Select(x => x.Name)
            .ToList();

        // Access Token
        var accessToken =
            _jwtService.GenerateAccessToken(
                user.Id,
                user.Email,
                roleNames);

        // Refresh Token
        var refreshToken =
            _jwtService.GenerateRefreshToken();

        // Xóa RefreshToken cũ (nếu muốn chỉ cho phép 1 phiên đăng nhập)
        var oldTokens = await _unitOfWork.RefreshTokens
            .GetValidTokensByUserIdAsync(user.Id);

        foreach (var token in oldTokens)
        {
            token.RevokedAt = DateTime.UtcNow;
        }

        // Lưu RefreshToken mới
        await _unitOfWork.RefreshTokens.AddAsync(
            new RefreshToken
            {
                UserId = user.Id,
                Token = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            });

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Response
        var response =
            _mapper.Map<AuthResponseDto>(user);

        response.AccessToken = accessToken;
        response.RefreshToken = refreshToken;
        response.Roles = roleNames;

        return Result<AuthResponseDto>.Success(response);
    }
}