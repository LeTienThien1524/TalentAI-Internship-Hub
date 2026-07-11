using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Educations.DTOs;

using TalentAI.Domain.Entities.Profiles;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Educations.Commands.CreateEducation;

public class CreateEducationCommandHandler
    : IRequestHandler<
        CreateEducationCommand,
        Result<EducationDto>>
{
    private readonly IEducationRepository
        _educationRepository;

    public CreateEducationCommandHandler(
        IEducationRepository educationRepository)
    {
        _educationRepository =
            educationRepository;
    }

    public async Task<Result<EducationDto>>
        Handle(
            CreateEducationCommand request,
            CancellationToken cancellationToken)
    {
        var education = new Education
        {
            CandidateId = request.CandidateId,
            University = request.University,
            Major = request.Major,
            Degree = request.Degree,
            GPA = request.GPA,
            StartYear = request.StartYear,
            EndYear = request.EndYear
        };

        await _educationRepository
            .AddAsync(education);

        await _educationRepository
            .SaveChangesAsync();

        return Result<EducationDto>
            .Success(
                new EducationDto
                {
                    Id = education.Id,
                    University = education.University,
                    Major = education.Major,
                    Degree = education.Degree,
                    GPA = education.GPA,
                    StartYear = education.StartYear,
                    EndYear = education.EndYear
                });
    }
}
