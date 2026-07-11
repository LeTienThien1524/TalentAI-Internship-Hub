using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MatchScoreDto
{
    public Guid JobApplicationId { get; set; }

    public decimal MatchPercentage { get; set; }

    public string? CoreStrengths { get; set; }

    public string? SkillGaps { get; set; }

    public string? AIExplanation { get; set; }
}
