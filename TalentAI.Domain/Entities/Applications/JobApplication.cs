using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Common;
using TalentAI.Domain.Entities.Jobs;
using TalentAI.Domain.Entities.Profiles;
using TalentAI.Domain.Entities.Resumes;

namespace TalentAI.Domain.Entities.Applications;

public class JobApplication : BaseEntity
{
    public Guid CandidateId { get; set; }

    public Guid JobPostingId { get; set; }

    public Guid ResumeId { get; set; }

    public string? CoverLetter { get; set; }

    public DateTime AppliedAt { get; set; }

    public Candidate Candidate { get; set; } = null!;

    public JobPosting JobPosting { get; set; } = null!;

    public Resume Resume { get; set; } = null!;

    public ICollection<ApplicationHistory> ApplicationHistories { get; set; }
        = new List<ApplicationHistory>();

    public ICollection<Interview> Interviews { get; set; }
        = new List<Interview>();

    public AIMatchScore? AIMatchScore { get; set; }
}
