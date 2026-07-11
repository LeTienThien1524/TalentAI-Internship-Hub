using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace TalentAI.Application.Features.Resumes.Commands.UploadResume;

public class UploadResumeCommandValidator
    : AbstractValidator<UploadResumeCommand>
{
    public UploadResumeCommandValidator()
    {
        RuleFor(x => x.FileName)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(x => x.FilePath)
            .NotEmpty()
            .MaximumLength(512);
    }
}
