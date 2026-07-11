using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Entities.Metadata;

namespace TalentAI.Domain.Entities.Profiles;

public class CandidateSkill
{
    public Guid CandidateId { get; set; }

    public int SkillId { get; set; }

    public Candidate Candidate { get; set; } = null!;

    public Skill Skill { get; set; } = null!;
}
