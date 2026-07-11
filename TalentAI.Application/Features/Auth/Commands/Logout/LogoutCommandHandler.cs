using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Auth.Commands.Logout;

public class LogoutCommandHandler
    : IRequestHandler<LogoutCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public LogoutCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        LogoutCommand request,
        CancellationToken cancellationToken)
    {
        var token = await _unitOfWork.RefreshTokens
            .GetByTokenAsync(request.RefreshToken);

        if (token is null)
        {
            return Result.NotFound("Refresh token not found.");
        }

        token.IsRevoked = true;

        _unitOfWork.RefreshTokens.Update(token);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success("Logout successfully.");
    }
}
