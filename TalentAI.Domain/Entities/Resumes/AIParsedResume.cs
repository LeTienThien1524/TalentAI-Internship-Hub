using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Common;

namespace TalentAI.Domain.Entities.Resumes;

public class AIParsedResume : BaseEntity
{
    public Guid ResumeId { get; set; }

    public string? RawText { get; set; }

    public string? Summary { get; set; }

    public string? ParsedSkills { get; set; }

    public string? ParsedEducation { get; set; }

    public string? ParsedExperience { get; set; }

    public DateTime ParsedAt { get; set; }

    public Resume Resume { get; set; } = null!;
}
