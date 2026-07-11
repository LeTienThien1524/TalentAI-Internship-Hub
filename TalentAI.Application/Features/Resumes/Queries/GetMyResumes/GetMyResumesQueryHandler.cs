using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Resumes.DTOs;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Resumes.Queries.GetMyResumes;

public class GetMyResumesQueryHandler
    : IRequestHandler<
        GetMyResumesQuery,
        Result<List<ResumeDto>>>
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly IResumeRepository _resumeRepository;
    private readonly ICurrentUserService _currentUser;

    public GetMyResumesQueryHandler(
        ICandidateRepository candidateRepository,
        IResumeRepository resumeRepository,
        ICurrentUserService currentUser)
    {
        _candidateRepository = candidateRepository;
        _resumeRepository = resumeRepository;
        _currentUser = currentUser;
    }

    public async Task<Result<List<ResumeDto>>> Handle(
        GetMyResumesQuery request,
        CancellationToken cancellationToken)
    {
        var candidate =
            await _candidateRepository.GetByUserIdAsync(
                _currentUser.UserId);

        if (candidate == null)
        {
            return Result<List<ResumeDto>>
                .Failure("Candidate profile not found.");
        }

        var resumes =
            await _resumeRepository
                .GetByCandidateIdAsync(candidate.Id);

        var result = resumes
            .Select(x => new ResumeDto
            {
                Id = x.Id,
                CandidateId = x.CandidateId,
                FileName = x.FileName,
                FilePath = x.FilePath,
                UploadedAt = x.UploadedAt
            })
            .ToList();

        return Result<List<ResumeDto>>
            .Success(result);
    }
}
