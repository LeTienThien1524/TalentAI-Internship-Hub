using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;

namespace TalentAI.Application.Features.Skills.Commands.DeleteSkill;

public class DeleteSkillCommand : IRequest<Result>
{
    public int Id { get; set; }
}
