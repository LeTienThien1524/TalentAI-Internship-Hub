using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Common;
using TalentAI.Domain.Entities.Applications;
using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Domain.Entities.Resumes;

public class Resume : BaseEntity
{
    public Guid CandidateId { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public DateTime UploadedAt { get; set; }

    public Candidate Candidate { get; set; } = null!;

    public AIParsedResume? AIParsedResume { get; set; }

    public ICollection<JobApplication> JobApplications { get; set; }
        = new List<JobApplication>();
}
