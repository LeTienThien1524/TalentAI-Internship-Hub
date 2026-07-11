using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Skills.DTOs;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Skills.Queries.GetSkillById;

public class GetSkillByIdQueryHandler
    : IRequestHandler<
        GetSkillByIdQuery,
        Result<SkillDto>>
{
    private readonly ISkillRepository _skillRepository;

    private readonly IMapper _mapper;

    public GetSkillByIdQueryHandler(
        ISkillRepository skillRepository,
        IMapper mapper)
    {
        _skillRepository = skillRepository;
        _mapper = mapper;
    }

    public async Task<Result<SkillDto>> Handle(
        GetSkillByIdQuery request,
        CancellationToken cancellationToken)
    {
        var skill =
            await _skillRepository.GetByIdAsync(request.Id);

        if (skill is null)
        {
            return Result<SkillDto>.NotFound(
                "Skill not found.");
        }

        var dto =
            _mapper.Map<SkillDto>(skill);

        return Result<SkillDto>.Success(dto);
    }
}
