using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Resumes.DTOs;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Entities.Resumes;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Resumes.Commands.UploadResume;

public class UploadResumeCommandHandler
    : IRequestHandler<
        UploadResumeCommand,
        Result<ResumeDto>>
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly IResumeRepository _resumeRepository;
    private readonly ICurrentUserService _currentUser;
    private readonly IUnitOfWork _unitOfWork;

    public UploadResumeCommandHandler(
        ICandidateRepository candidateRepository,
        IResumeRepository resumeRepository,
        ICurrentUserService currentUser,
        IUnitOfWork unitOfWork)
    {
        _candidateRepository = candidateRepository;
        _resumeRepository = resumeRepository;
        _currentUser = currentUser;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ResumeDto>> Handle(
        UploadResumeCommand request,
        CancellationToken cancellationToken)
    {
        var candidate =
            await _candidateRepository.GetByUserIdAsync(
                _currentUser.UserId);

        if (candidate == null)
        {
            return Result<ResumeDto>.Failure(
                "Candidate profile not found.");
        }

        var resume = new Resume
        {
            CandidateId = candidate.Id,
            FileName = request.FileName,
            FilePath = request.FilePath,
            UploadedAt = DateTime.UtcNow
        };

        await _resumeRepository.AddAsync(resume);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result<ResumeDto>.Success(
            new ResumeDto
            {
                Id = resume.Id,
                CandidateId = resume.CandidateId,
                FileName = resume.FileName,
                FilePath = resume.FilePath,
                UploadedAt = resume.UploadedAt
            });
    }
}
