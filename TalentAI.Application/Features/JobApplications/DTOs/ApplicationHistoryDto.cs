using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Enums;

namespace TalentAI.Application.Features.JobApplications.DTOs;

public class ApplicationHistoryDto
{
    public Guid Id { get; set; }

    public Guid JobApplicationId { get; set; }

    public Guid ChangedByUserId { get; set; }

    public ApplicationStatus Status { get; set; }

    public string? Note { get; set; }

    public DateTime ChangedAt { get; set; }
}
