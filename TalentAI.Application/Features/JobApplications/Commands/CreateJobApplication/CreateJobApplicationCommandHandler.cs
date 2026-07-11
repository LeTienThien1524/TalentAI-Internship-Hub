using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobApplications.DTOs;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Entities.Applications;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.JobApplications.Commands.CreateJobApplication;

public class CreateJobApplicationCommandHandler
    : IRequestHandler<
        CreateJobApplicationCommand,
        Result<JobApplicationDto>>
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly IResumeRepository _resumeRepository;
    private readonly IJobApplicationRepository _jobApplicationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUser;

    public CreateJobApplicationCommandHandler(
        ICandidateRepository candidateRepository,
        IResumeRepository resumeRepository,
        IJobApplicationRepository jobApplicationRepository,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUser)
    {
        _candidateRepository = candidateRepository;
        _resumeRepository = resumeRepository;
        _jobApplicationRepository = jobApplicationRepository;
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
    }

    public async Task<Result<JobApplicationDto>> Handle(
        CreateJobApplicationCommand request,
        CancellationToken cancellationToken)
    {
        var candidate =
            await _candidateRepository.GetByUserIdAsync(
                _currentUser.UserId);

        if (candidate == null)
        {
            return Result<JobApplicationDto>.Failure(
                "Candidate profile not found.");
        }

        var resume =
            await _resumeRepository.GetByIdAsync(
                request.ResumeId);

        if (resume == null)
        {
            return Result<JobApplicationDto>.Failure(
                "Resume not found.");
        }

        if (resume.CandidateId != candidate.Id)
        {
            return Result<JobApplicationDto>.Failure(
                "Resume does not belong to current candidate.");
        }

        var hasApplied =
            await _jobApplicationRepository.HasAppliedAsync(
                candidate.Id,
                request.JobPostingId);

        if (hasApplied)
        {
            return Result<JobApplicationDto>.Failure(
                "You have already applied for this job.");
        }

        var application = new JobApplication
        {
            CandidateId = candidate.Id,
            JobPostingId = request.JobPostingId,
            ResumeId = request.ResumeId,
            CoverLetter = request.CoverLetter,
            AppliedAt = DateTime.UtcNow
        };

        await _jobApplicationRepository.AddAsync(
            application);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result<JobApplicationDto>.Success(
            new JobApplicationDto
            {
                Id = application.Id,
                CandidateId = application.CandidateId,
                JobPostingId = application.JobPostingId,
                ResumeId = application.ResumeId,
                CoverLetter = application.CoverLetter,
                AppliedAt = application.AppliedAt
            });
    }
}
