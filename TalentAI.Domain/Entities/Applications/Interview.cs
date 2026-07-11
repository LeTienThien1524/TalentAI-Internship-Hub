using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Common;

namespace TalentAI.Domain.Entities.Applications;

public class Interview : BaseEntity
{
    public Guid JobApplicationId { get; set; }

    public DateTime ScheduledAt { get; set; }

    public string LocationOrLink { get; set; } = string.Empty;

    public string InterviewerName { get; set; } = string.Empty;

    public string? Notes { get; set; }

    public JobApplication JobApplication { get; set; } = null!;
}
