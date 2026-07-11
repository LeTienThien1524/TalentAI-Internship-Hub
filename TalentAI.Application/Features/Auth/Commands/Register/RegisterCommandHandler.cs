using AutoMapper;
using MediatR;

using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Auth.DTOs;
using TalentAI.Application.Interfaces;

using TalentAI.Domain.Entities.Identity;
using TalentAI.Domain.Entities.Profiles;
using TalentAI.Domain.Entities.System;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler
    : IRequestHandler<RegisterCommand, Result<AuthResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtService _jwtService;
    private readonly IMapper _mapper;

    public RegisterCommandHandler(
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
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        // Email tồn tại
        if (await _unitOfWork.Users.ExistsByEmailAsync(request.Email))
        {
            return Result<AuthResponseDto>.Failure(
                "Email already exists.");
        }

        // Role
        var role = await _unitOfWork.Roles.GetByNameAsync(request.Role);

        if (role is null)
        {
            return Result<AuthResponseDto>.Failure(
                "Role not found.");
        }

        // User
        var user = new User
        {
            Email = request.Email,
            PasswordHash =
                _passwordHasher.HashPassword(request.Password),
            IsActive = true
        };

        await _unitOfWork.Users.AddAsync(user);

        // UserRole
        await _unitOfWork.UserRoles.AssignRoleAsync(
            user.Id,
            role.Id);

        // Candidate
        if (role.NormalizedName == "CANDIDATE")
        {
            await _unitOfWork.Candidates.AddAsync(
                new Candidate
                {
                    UserId = user.Id,
                    ProvinceId = 1,
                    FullName = string.Empty
                });
        }

        // Company
        if (role.NormalizedName == "COMPANY")
        {
            await _unitOfWork.Companies.AddAsync(
                new Company
                {
                    UserId = user.Id,
                    ProvinceId = 1,
                    CompanyName = string.Empty,
                    IsVerified = false
                });
        }

        // Access Token
        var roles = new List<string>
        {
            role.Name
        };

        var accessToken = _jwtService.GenerateAccessToken(
                user.Id,
                user.Email,
                roles);

        // Refresh Token
        var refreshToken = _jwtService.GenerateRefreshToken();

        await _unitOfWork.RefreshTokens.AddAsync(
            new RefreshToken
            {
                UserId = user.Id,
                Token = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            });

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        var response = _mapper.Map<AuthResponseDto>(user);

        response.AccessToken = accessToken;
        response.RefreshToken = refreshToken;
        response.Roles = roles;

        return Result<AuthResponseDto>.Success(response);
    }
}
