using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace TalentAI.Application.Features.Provinces.Commands.UpdateProvince;

public class UpdateProvinceCommandValidator
    : AbstractValidator<UpdateProvinceCommand>
{
    public UpdateProvinceCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Invalid province id.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Province name is required.")

            .MaximumLength(100)
            .WithMessage("Province name cannot exceed 100 characters.");
    }
}
