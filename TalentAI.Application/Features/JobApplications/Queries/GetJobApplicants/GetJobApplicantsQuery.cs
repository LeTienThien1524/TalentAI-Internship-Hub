using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobApplications.DTOs;

namespace TalentAI.Application.Features.JobApplications.Queries.GetJobApplicants;

public class GetJobApplicantsQuery
    : IRequest<Result<List<JobApplicationDto>>>
{
    public Guid JobPostingId { get; set; }
}
