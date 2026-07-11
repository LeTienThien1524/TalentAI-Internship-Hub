using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using TalentAI.Application.Features.JobPostings.DTOs;

using TalentAI.Domain.Entities.Jobs;

namespace TalentAI.Application.Mappings;

public class JobPostingMappingProfile : Profile
{
    public JobPostingMappingProfile()
    {
        CreateMap<JobPosting, JobPostingDto>();
    }
}
