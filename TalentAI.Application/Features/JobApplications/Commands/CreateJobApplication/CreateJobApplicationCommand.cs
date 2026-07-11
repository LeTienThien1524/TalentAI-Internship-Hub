using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobApplications.DTOs;

namespace TalentAI.Application.Features.JobApplications.Commands.CreateJobApplication;

public class CreateJobApplicationCommand
    : IRequest<Result<JobApplicationDto>>
{
    public Guid JobPostingId { get; set; }

    public Guid ResumeId { get; set; }

    public string? CoverLetter { get; set; }
}
