using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Skills.DTOs;

using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Skills.Queries.GetSkills;

public class GetSkillsQueryHandler
    : IRequestHandler<
        GetSkillsQuery,
        Result<List<SkillDto>>>
{
    private readonly ISkillRepository
        _skillRepository;

    public GetSkillsQueryHandler(
        ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<Result<List<SkillDto>>>
        Handle(
            GetSkillsQuery request,
            CancellationToken cancellationToken)
    {
        var skills =
            await _skillRepository
                .GetAllAsync();

        var result = skills
            .Select(x => new SkillDto
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToList();

        return Result<List<SkillDto>>
            .Success(result);
    }
}
