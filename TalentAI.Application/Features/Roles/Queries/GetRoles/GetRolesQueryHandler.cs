using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Roles.DTOs;

using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Roles.Queries.GetRoles;

public class GetRolesQueryHandler
    : IRequestHandler<
        GetRolesQuery,
        Result<List<RoleDto>>>
{
    private readonly IRoleRepository _roleRepository;

    public GetRolesQueryHandler(
        IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Result<List<RoleDto>>> Handle(
        GetRolesQuery request,
        CancellationToken cancellationToken)
    {
        var roles =
            await _roleRepository.GetAllAsync();

        var result = roles
            .Where(x => !x.IsDeleted)
            .Select(x => new RoleDto
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToList();

        return Result<List<RoleDto>>
            .Success(result);
    }
}
