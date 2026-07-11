using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Entities.Jobs;
using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Domain.Entities.Metadata;

public class Skill
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<CandidateSkill> CandidateSkills { get; set; }
        = new List<CandidateSkill>();

    public ICollection<JobSkill> JobSkills { get; set; }
        = new List<JobSkill>();
}
