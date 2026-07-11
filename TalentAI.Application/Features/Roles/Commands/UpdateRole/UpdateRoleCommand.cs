using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace TalentAI.Application.Features.Roles.Commands.UpdateRole;

public class UpdateRoleCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
