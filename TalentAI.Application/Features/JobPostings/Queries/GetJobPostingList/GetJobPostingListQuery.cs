using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobPostings.DTOs;

namespace TalentAI.Application.Features.JobPostings.Queries.GetJobPostingList;

public class GetJobPostingListQuery
    : IRequest<Result<List<JobPostingDto>>>
{
}
