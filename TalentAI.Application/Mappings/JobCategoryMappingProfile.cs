using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using TalentAI.Application.Features.JobCategories.DTOs;

using TalentAI.Domain.Entities.Metadata;

namespace TalentAI.Application.Mappings;

public class JobCategoryMappingProfile : Profile
{
    public JobCategoryMappingProfile()
    {
        CreateMap<JobCategory, JobCategoryDto>();
    }
}
