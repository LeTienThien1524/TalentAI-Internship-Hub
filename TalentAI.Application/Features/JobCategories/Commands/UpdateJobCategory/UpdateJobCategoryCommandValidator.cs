using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace TalentAI.Application.Features.JobCategories.Commands.UpdateJobCategory;

public class UpdateJobCategoryCommandValidator
    : AbstractValidator<UpdateJobCategoryCommand>
{
    public UpdateJobCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Invalid job category id.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Job category name is required.")

            .MaximumLength(100)
            .WithMessage("Job category name cannot exceed 100 characters.");
    }
}
