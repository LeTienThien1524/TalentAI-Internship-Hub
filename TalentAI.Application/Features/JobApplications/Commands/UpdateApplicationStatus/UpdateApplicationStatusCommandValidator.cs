using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace TalentAI.Application.Features.JobApplications.Commands.UpdateApplicationStatus;

public class UpdateApplicationStatusCommandValidator
    : AbstractValidator<UpdateApplicationStatusCommand>
{
    public UpdateApplicationStatusCommandValidator()
    {
        RuleFor(x => x.JobApplicationId)
            .NotEmpty();
    }
}
