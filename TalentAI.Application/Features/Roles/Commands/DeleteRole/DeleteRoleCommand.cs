using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace TalentAI.Application.Features.Roles.Commands.DeleteRole;

public class DeleteRoleCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
