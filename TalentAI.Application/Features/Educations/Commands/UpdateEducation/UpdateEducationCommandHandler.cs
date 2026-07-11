using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Educations.Commands.UpdateEducation;

public class UpdateEducationCommandHandler
    : IRequestHandler<
        UpdateEducationCommand,
        Result>
{
    private readonly IEducationRepository
        _educationRepository;

    public UpdateEducationCommandHandler(
        IEducationRepository educationRepository)
    {
        _educationRepository =
            educationRepository;
    }

    public async Task<Result>
        Handle(
            UpdateEducationCommand request,
            CancellationToken cancellationToken)
    {
        var education =
            await _educationRepository
                .GetByIdAsync(request.Id);

        if (education is null)
        {
            return Result.Failure(
                "Education not found");
        }

        education.University= request.University;
        education.Major = request.Major;
        education.Degree = request.Degree;
        education.GPA = request.GPA;
        education.StartYear = request.StartYear;
        education.EndYear = request.EndYear;

        _educationRepository.Update(education);

        await _educationRepository
            .SaveChangesAsync();

        return Result.Success();
    }
}
