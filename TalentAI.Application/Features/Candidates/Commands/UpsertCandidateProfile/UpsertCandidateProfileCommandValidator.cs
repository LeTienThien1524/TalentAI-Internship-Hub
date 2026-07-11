using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace TalentAI.Application.Features.Candidates.Commands;

public class UpsertCandidateProfileCommandValidator
    : AbstractValidator<UpsertCandidateProfileCommand>
{
    public UpsertCandidateProfileCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("FullName is required");
    }
}
