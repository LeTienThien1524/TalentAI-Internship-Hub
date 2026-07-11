using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Resumes.DTOs;

namespace TalentAI.Application.Features.Resumes.Commands.UploadResume;

public class UploadResumeCommand
    : IRequest<Result<ResumeDto>>
{
    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;
}
