using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace TalentAI.Application.Features.JobCategories.Commands.DeleteJobCategory;

public class DeleteJobCategoryCommandValidator
    : AbstractValidator<DeleteJobCategoryCommand>
{
    public DeleteJobCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Invalid job category id.");
    }
}
