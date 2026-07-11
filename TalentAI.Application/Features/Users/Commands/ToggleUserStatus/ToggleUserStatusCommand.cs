using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;

namespace TalentAI.Application.Features.Users.Commands.ToggleUserStatus;

public class ToggleUserStatusCommand
    : IRequest<Result>
{
    public Guid UserId { get; set; }

    public ToggleUserStatusCommand(Guid userId)
    {
        UserId = userId;
    }
}
