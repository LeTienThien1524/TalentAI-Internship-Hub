using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace TalentAI.Application.Features.JobCategories.Commands.CreateJobCategory;

public class CreateJobCategoryCommandValidator
    : AbstractValidator<CreateJobCategoryCommand>
{
    public CreateJobCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Job category name is required.")

            .MaximumLength(100)
            .WithMessage("Job category name cannot exceed 100 characters.");
    }
}
