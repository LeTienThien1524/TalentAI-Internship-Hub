using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobPostings.DTOs;

namespace TalentAI.Application.Features.JobPostings.Queries.GetJobPostingById;

public class GetJobPostingByIdQuery
    : IRequest<Result<JobPostingDto>>
{
    public Guid Id { get; set; }
}
