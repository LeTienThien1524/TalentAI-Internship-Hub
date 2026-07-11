using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using TalentAI.Application.Features.Interviews.DTOs;

using TalentAI.Domain.Entities.Applications;

namespace TalentAI.Application.Mappings;

public class InterviewMappingProfile : Profile
{
    public InterviewMappingProfile()
    {
        CreateMap<Interview, InterviewDto>();
    }
}
