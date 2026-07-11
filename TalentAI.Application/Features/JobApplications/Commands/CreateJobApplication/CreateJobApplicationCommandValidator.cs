using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace TalentAI.Application.Features.JobApplications.Commands.CreateJobApplication;

public class CreateJobApplicationCommandValidator
    : AbstractValidator<CreateJobApplicationCommand>
{
    public CreateJobApplicationCommandValidator()
    {
        RuleFor(x => x.JobPostingId)
            .NotEmpty();

        RuleFor(x => x.ResumeId)
            .NotEmpty();
    }
}
