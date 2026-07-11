using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Educations.Commands.DeleteEducation;

public class DeleteEducationCommandHandler
    : IRequestHandler<
        DeleteEducationCommand,
        Result>
{
    private readonly IEducationRepository
        _educationRepository;

    public DeleteEducationCommandHandler(
        IEducationRepository educationRepository)
    {
        _educationRepository =
            educationRepository;
    }

    public async Task<Result>
        Handle(
            DeleteEducationCommand request,
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

        _educationRepository.Delete(education);

        await _educationRepository
            .SaveChangesAsync();

        return Result.Success();
    }
}
