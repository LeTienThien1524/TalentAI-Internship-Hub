using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Common;

namespace TalentAI.Domain.Entities.Profiles;

public class Certificate : BaseEntity
{
    public Guid CandidateId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Issuer { get; set; } = string.Empty;

    public DateTime? IssueDate { get; set; }

    public Candidate Candidate { get; set; } = null!;
}
