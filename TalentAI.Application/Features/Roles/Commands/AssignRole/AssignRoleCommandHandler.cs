using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Domain.Entities.Identity;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Roles.Commands.AssignRole;

public class AssignRoleCommandHandler
    : IRequestHandler<
        AssignRoleCommand,
        Result>
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssignRoleCommandHandler(
        IUserRoleRepository userRoleRepository,
        IUnitOfWork unitOfWork)
    {
        _userRoleRepository = userRoleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        AssignRoleCommand request,
        CancellationToken cancellationToken)
    {
        var existed =
            await _userRoleRepository
                .ExistsAsync(
                    request.UserId,
                    request.RoleId);

        if (existed)
        {
            return Result.Failure(
                "Role already assigned");
        }

        var userRole = new UserRole
        {
            UserId = request.UserId,
            RoleId = request.RoleId
        };

        await _userRoleRepository
            .AddAsync(userRole);

        await _unitOfWork
            .SaveChangesAsync(
                cancellationToken);

        return Result.Success();
    }
}
