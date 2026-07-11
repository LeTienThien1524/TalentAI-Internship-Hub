using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobApplications.DTOs;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.JobApplications.Queries.GetJobApplicants;

public class GetJobApplicantsQueryHandler
    : IRequestHandler<
        GetJobApplicantsQuery,
        Result<List<JobApplicationDto>>>
{
    private readonly IJobApplicationRepository
        _jobApplicationRepository;

    public GetJobApplicantsQueryHandler(
        IJobApplicationRepository jobApplicationRepository)
    {
        _jobApplicationRepository =
            jobApplicationRepository;
    }

    public async Task<Result<List<JobApplicationDto>>> Handle(
        GetJobApplicantsQuery request,
        CancellationToken cancellationToken)
    {
        var applications =
            await _jobApplicationRepository
                .GetByJobPostingIdAsync(
                    request.JobPostingId);

        var result = applications
            .Select(x => new JobApplicationDto
            {
                Id = x.Id,
                CandidateId = x.CandidateId,
                JobPostingId = x.JobPostingId,
                ResumeId = x.ResumeId,
                CoverLetter = x.CoverLetter,
                AppliedAt = x.AppliedAt
            })
            .ToList();

        return Result<List<JobApplicationDto>>
            .Success(result);
    }
}
