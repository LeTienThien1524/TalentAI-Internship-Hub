using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace TalentAI.Application.Features.JobPostings.Commands.CreateJobPosting;

public class CreateJobPostingCommandValidator
    : AbstractValidator<CreateJobPostingCommand>
{
    public CreateJobPostingCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(x => x.Description)
            .NotEmpty();

        RuleFor(x => x.Requirements)
            .NotEmpty();

        RuleFor(x => x.JobCategoryId)
            .GreaterThan(0);

        RuleFor(x => x.ProvinceId)
            .GreaterThan(0);

        RuleFor(x => x.Deadline)
            .GreaterThan(DateTime.UtcNow);
    }
}
