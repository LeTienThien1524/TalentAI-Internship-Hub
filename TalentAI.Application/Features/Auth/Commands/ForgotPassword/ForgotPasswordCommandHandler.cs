using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Entities.Identity;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Auth.Commands.ForgotPassword;

public class ForgotPasswordCommandHandler
    : IRequestHandler<ForgotPasswordCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;

    public ForgotPasswordCommandHandler(
        IUnitOfWork unitOfWork,
        IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _emailService = emailService;
    }

    public async Task<Result> Handle(
        ForgotPasswordCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users
            .GetByEmailAsync(request.Email);

        if (user is null)
        {
            return Result.NotFound("User not found.");
        }

        // Thu hồi toàn bộ token cũ
        await _unitOfWork.PasswordResetTokens
            .RevokeAllAsync(user.Id);

        var token = Convert.ToHexString(
            Guid.NewGuid().ToByteArray());

        await _unitOfWork.PasswordResetTokens.AddAsync(
            new PasswordResetToken
            {
                UserId = user.Id,
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddMinutes(30),
                IsUsed = false
            });

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var body =
            $"""
                    Hello {user.Email},

                    You requested to reset your password.

                    Reset Token:

                    {token}

                    This token will expire in 30 minutes.

                    If you did not request this, please ignore this email.

                    TalentAI Internship Hub
                    """;

        await _emailService.SendEmailAsync(
            user.Email,
            "Reset Password",
            body);

        return Result.Success(
            "Reset password email sent successfully.");
    }
}