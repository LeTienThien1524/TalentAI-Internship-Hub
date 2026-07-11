using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Common;

namespace TalentAI.Domain.Entities.Applications;

public class AIMatchScore : BaseEntity
{
    public Guid JobApplicationId { get; set; }

    public decimal MatchPercentage { get; set; }

    public string? CoreStrengths { get; set; }

    public string? SkillGaps { get; set; }

    public string? AIExplanation { get; set; }

    public DateTime EvaluatedAt { get; set; }

    public JobApplication JobApplication { get; set; } = null!;
}
