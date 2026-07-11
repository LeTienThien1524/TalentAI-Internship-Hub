using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Entities.Metadata;

namespace TalentAI.Domain.Entities.Jobs;

public class JobSkill
{
    public Guid JobPostingId { get; set; }

    public int SkillId { get; set; }

    public bool IsRequired { get; set; }

    public JobPosting JobPosting { get; set; } = null!;

    public Skill Skill { get; set; } = null!;
}
