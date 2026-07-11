using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Roles.DTOs;

namespace TalentAI.Application.Features.Roles.Queries.GetUserRoles;

public class GetUserRolesQuery
    : IRequest<Result<List<RoleDto>>>
{
    public Guid UserId { get; set; }

    public GetUserRolesQuery(Guid userId)
    {
        UserId = userId;
    }
}
