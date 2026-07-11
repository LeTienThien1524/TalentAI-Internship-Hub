using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Roles.DTOs;

using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Roles.Queries.GetUserRoles;

public class GetUserRolesQueryHandler
    : IRequestHandler<
        GetUserRolesQuery,
        Result<List<RoleDto>>>
{
    private readonly IUserRoleRepository _userRoleRepository;

    public GetUserRolesQueryHandler(
        IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }

    public async Task<Result<List<RoleDto>>> Handle(
        GetUserRolesQuery request,
        CancellationToken cancellationToken)
    {
        var roles =
            await _userRoleRepository
                .GetByUserIdAsync(
                    request.UserId);

        var result = roles
            .Select(x => new RoleDto
            {
                Id = x.Role.Id,
                Name = x.Role.Name
            })
            .ToList();

        return Result<List<RoleDto>>
            .Success(result);
    }
}
