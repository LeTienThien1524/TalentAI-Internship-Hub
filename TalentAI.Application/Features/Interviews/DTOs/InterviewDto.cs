using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAI.Application.Features.Interviews.DTOs;

public class InterviewDto
{
    public Guid Id { get; set; }

    public Guid JobApplicationId { get; set; }

    public DateTime ScheduledAt { get; set; }

    public string LocationOrLink { get; set; }
        = string.Empty;

    public string InterviewerName { get; set; }
        = string.Empty;

    public string? Notes { get; set; }
}
