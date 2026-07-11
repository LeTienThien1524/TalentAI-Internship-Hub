using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace TalentAI.Application.Features.Companies.Commands.UpsertCompanyProfile;

public class UpsertCompanyProfileCommandValidator
    : AbstractValidator<UpsertCompanyProfileCommand>
{
    public UpsertCompanyProfileCommandValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(x => x.ProvinceId)
            .GreaterThan(0);
    }
}
