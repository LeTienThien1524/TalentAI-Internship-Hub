using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Auth.Commands.RefreshAccessToken;
using TalentAI.Application.Features.Auth.DTOs;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Entities.Identity;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Auth.Commands.RefreshAccessToken;

public class RefreshTokenCommandHandler
    : IRequestHandler<RefreshTokenCommand, Result<AuthResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;
    private readonly IMapper _mapper;

    public RefreshTokenCommandHandler(
        IUnitOfWork unitOfWork,
        IJwtService jwtService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
        _mapper = mapper;
    }

    public async Task<Result<AuthResponseDto>> Handle(
        RefreshTokenCommand request,
        CancellationToken cancellationToken)
    {
        var refreshToken = await _unitOfWork.RefreshTokens
            .GetByTokenAsync(request.RefreshToken);

        if (refreshToken is null)
            return Result<AuthResponseDto>.Unauthorized("Invalid refresh token.");

        if (refreshToken.IsRevoked)
            return Result<AuthResponseDto>.Unauthorized("Refresh token revoked.");

        if (refreshToken.ExpiresAt < DateTime.UtcNow)
            return Result<AuthResponseDto>.Unauthorized("Refresh token expired.");

        var user = await _unitOfWork.Users
            .GetByIdAsync(refreshToken.UserId);

        if (user is null)
            return Result<AuthResponseDto>.NotFound("User not found.");

        var roles = await _unitOfWork.UserRoles
            .GetRolesByUserIdAsync(user.Id);

        var roleNames = roles
            .Select(x => x.Name)
            .ToList();

        refreshToken.IsRevoked = true;

        _unitOfWork.RefreshTokens.Update(refreshToken);

        var newRefresh = new RefreshToken
        {
            UserId = user.Id,
            Token = _jwtService.GenerateRefreshToken(),
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        };

        await _unitOfWork.RefreshTokens.AddAsync(newRefresh);

        var accessToken = _jwtService.GenerateAccessToken(
            user.Id,
            user.Email,
            roleNames);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = _mapper.Map<AuthResponseDto>(user);

        response.AccessToken = accessToken;
        response.RefreshToken = newRefresh.Token;
        response.Roles = roleNames;

        return Result<AuthResponseDto>.Success(response);
    }
}
