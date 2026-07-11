using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace TalentAI.Application.Features.Skills.Commands.UpdateSkill;

public class UpdateSkillCommandValidator
    : AbstractValidator<UpdateSkillCommand>
{
    public UpdateSkillCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Invalid skill id.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Skill name is required.")

            .MaximumLength(100)
            .WithMessage("Skill name cannot exceed 100 characters.");
    }
}
