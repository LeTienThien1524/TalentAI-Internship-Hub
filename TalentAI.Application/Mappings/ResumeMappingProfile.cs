using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using TalentAI.Application.Features.Resumes.DTOs;

using TalentAI.Domain.Entities.Resumes;

namespace TalentAI.Application.Mappings;

public class ResumeMappingProfile : Profile
{
    public ResumeMappingProfile()
    {
        CreateMap<Resume, ResumeDto>();
    }
}
