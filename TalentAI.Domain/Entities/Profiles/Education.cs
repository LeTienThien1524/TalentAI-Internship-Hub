using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Common;
using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Domain.Entities.Profiles;

public class Education : BaseEntity
{
    public Guid CandidateId { get; set; }

    public string University { get; set; } = string.Empty;

    public string Major { get; set; } = string.Empty;

    public string Degree { get; set; } = string.Empty;

    public decimal? GPA { get; set; }

    public int StartYear { get; set; }

    public int? EndYear { get; set; }

    public Candidate Candidate { get; set; } = null!;
}
