using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordCommandHandler
    : IRequestHandler<ResetPasswordCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;

    public ResetPasswordCommandHandler(
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result> Handle(
        ResetPasswordCommand request,
        CancellationToken cancellationToken)
    {
        var resetToken = await _unitOfWork.PasswordResetTokens
            .GetByTokenAsync(request.Token);

        if (resetToken is null)
        {
            return Result.NotFound("Invalid token.");
        }

        if (resetToken.IsUsed)
        {
            return Result.Failure("Token has already been used.");
        }

        if (resetToken.ExpiresAt < DateTime.UtcNow)
        {
            return Result.Failure("Token has expired.");
        }

        var user = await _unitOfWork.Users
            .GetByIdAsync(resetToken.UserId);

        if (user is null)
        {
            return Result.NotFound("User not found.");
        }

        user.PasswordHash = _passwordHasher
            .HashPassword(request.NewPassword);

        _unitOfWork.Users.Update(user);

        resetToken.IsUsed = true;

        _unitOfWork.PasswordResetTokens.Update(resetToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success("Password reset successfully.");
    }
}
