using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Domain.Entities.Resumes;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.AI.Commands.ParseResume;

public class ParseResumeCommandHandler
    : IRequestHandler<
        ParseResumeCommand,
        Result<ParsedResumeDto>>
{
    private readonly IResumeRepository _resumeRepository;
    private readonly IAIParsedResumeRepository _parsedRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ParseResumeCommandHandler(
        IResumeRepository resumeRepository,
        IAIParsedResumeRepository parsedRepository,
        IUnitOfWork unitOfWork)
    {
        _resumeRepository = resumeRepository;
        _parsedRepository = parsedRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ParsedResumeDto>> Handle(
        ParseResumeCommand request,
        CancellationToken cancellationToken)
    {
        var resume =
            await _resumeRepository
                .GetByIdAsync(request.ResumeId);

        if (resume == null)
        {
            return Result<ParsedResumeDto>
                .Failure("Resume not found.");
        }

        var parsed = new AIParsedResume
        {
            ResumeId = resume.Id,
            Summary =
                "Candidate has software development background.",
            ParsedSkills =
                "C#, ASP.NET Core, SQL Server",
            ParsedEducation =
                "University",
            ParsedExperience =
                "Internship Project",
            ParsedAt = DateTime.UtcNow
        };

        await _parsedRepository.AddAsync(parsed);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result<ParsedResumeDto>.Success(
            new ParsedResumeDto
            {
                ResumeId = parsed.ResumeId,
                Summary = parsed.Summary,
                ParsedSkills = parsed.ParsedSkills,
                ParsedEducation = parsed.ParsedEducation,
                ParsedExperience = parsed.ParsedExperience
            });
    }
}
