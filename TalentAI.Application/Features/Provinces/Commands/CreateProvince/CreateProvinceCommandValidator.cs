using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace TalentAI.Application.Features.Provinces.Commands.CreateProvince;

public class CreateProvinceCommandValidator
    : AbstractValidator<CreateProvinceCommand>
{
    public CreateProvinceCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Province name is required.")

            .MaximumLength(100)
            .WithMessage("Province name cannot exceed 100 characters.");
    }
}
