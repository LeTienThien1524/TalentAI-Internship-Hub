using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Skills.DTOs;

namespace TalentAI.Application.Features.Skills.Queries.GetSkillById;

public class GetSkillByIdQuery
    : IRequest<Result<SkillDto>>
{
    public int Id { get; set; }
}
