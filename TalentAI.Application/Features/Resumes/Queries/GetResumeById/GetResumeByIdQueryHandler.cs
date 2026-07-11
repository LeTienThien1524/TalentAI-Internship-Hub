using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Resumes.DTOs;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Resumes.Queries.GetResumeById;

public class GetResumeByIdQueryHandler
    : IRequestHandler<
        GetResumeByIdQuery,
        Result<ResumeDto>>
{
    private readonly IResumeRepository _resumeRepository;

    public GetResumeByIdQueryHandler(
        IResumeRepository resumeRepository)
    {
        _resumeRepository = resumeRepository;
    }

    public async Task<Result<ResumeDto>> Handle(
        GetResumeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var resume =
            await _resumeRepository.GetByIdAsync(
                request.Id);

        if (resume == null)
        {
            return Result<ResumeDto>.Failure(
                "Resume not found.");
        }

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
