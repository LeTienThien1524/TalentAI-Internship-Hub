using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using TalentAI.Application.Features.Skills.DTOs;

using TalentAI.Domain.Entities.Metadata;

namespace TalentAI.Application.Mappings;

public class SkillMappingProfile : Profile
{
    public SkillMappingProfile()
    {
        CreateMap<Skill, SkillDto>();
    }
}
