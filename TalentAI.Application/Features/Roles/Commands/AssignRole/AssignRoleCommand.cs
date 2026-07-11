using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;

namespace TalentAI.Application.Features.Roles.Commands.AssignRole;

public class AssignRoleCommand
    : IRequest<Result>
{
    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }
}
