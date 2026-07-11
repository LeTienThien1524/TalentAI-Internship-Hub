using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using TalentAI.Application.Features.Educations.DTOs;

using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Application.Mappings;

public class EducationMappingProfile : Profile
{
    public EducationMappingProfile()
    {
        CreateMap<Education, EducationDto>();
    }
}
