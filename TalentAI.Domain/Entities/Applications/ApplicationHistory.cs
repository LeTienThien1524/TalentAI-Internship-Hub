using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Common;
using TalentAI.Domain.Entities.Identity;
using TalentAI.Domain.Enums;

namespace TalentAI.Domain.Entities.Applications;

public class ApplicationHistory : BaseEntity
{
    public Guid JobApplicationId { get; set; }

    public Guid ChangedByUserId { get; set; }

    public ApplicationStatus Status { get; set; }

    public string? Note { get; set; }

    public DateTime ChangedAt { get; set; }

    public JobApplication JobApplication { get; set; } = null!;

    public User ChangedByUser { get; set; } = null!;
}
