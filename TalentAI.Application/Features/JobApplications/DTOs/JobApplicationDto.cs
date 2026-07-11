using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAI.Application.Features.JobApplications.DTOs;

public class JobApplicationDto
{
    public Guid Id { get; set; }

    public Guid CandidateId { get; set; }

    public Guid JobPostingId { get; set; }

    public Guid ResumeId { get; set; }

    public string? CoverLetter { get; set; }

    public DateTime AppliedAt { get; set; }
}
