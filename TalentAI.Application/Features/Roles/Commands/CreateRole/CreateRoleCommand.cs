using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;

namespace TalentAI.Application.Features.Roles.Commands.CreateRole;

public class CreateRoleCommand
    : IRequest<Result<Guid>>
{
    public string Name { get; set; } = string.Empty;
}
