using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Common;

namespace TalentAI.Domain.Entities.Profiles;

public class Experience : BaseEntity
{
    public Guid CandidateId { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public Candidate Candidate { get; set; } = null!;
}
