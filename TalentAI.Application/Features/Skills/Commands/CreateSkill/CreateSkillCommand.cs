using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;

namespace TalentAI.Application.Features.Skills.Commands.CreateSkill;

public class CreateSkillCommand : IRequest<Result<int>>
{
    public string Name { get; set; } = string.Empty;
}
