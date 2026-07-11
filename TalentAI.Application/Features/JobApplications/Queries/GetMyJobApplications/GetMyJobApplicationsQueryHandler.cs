using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobApplications.DTOs;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.JobApplications.Queries.GetMyJobApplications;

public class GetMyJobApplicationsQueryHandler
    : IRequestHandler<
        GetMyJobApplicationsQuery,
        Result<List<JobApplicationDto>>>
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly IJobApplicationRepository _jobApplicationRepository;
    private readonly ICurrentUserService _currentUser;

    public GetMyJobApplicationsQueryHandler(
        ICandidateRepository candidateRepository,
        IJobApplicationRepository jobApplicationRepository,
        ICurrentUserService currentUser)
    {
        _candidateRepository = candidateRepository;
        _jobApplicationRepository = jobApplicationRepository;
        _currentUser = currentUser;
    }

    public async Task<Result<List<JobApplicationDto>>> Handle(
        GetMyJobApplicationsQuery request,
        CancellationToken cancellationToken)
    {
        var candidate =
            await _candidateRepository.GetByUserIdAsync(
                _currentUser.UserId);

        if (candidate == null)
        {
            return Result<List<JobApplicationDto>>
                .Failure("Candidate profile not found.");
        }

        var applications =
            await _jobApplicationRepository
                .GetByCandidateIdAsync(candidate.Id);

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
