using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Common;
using TalentAI.Domain.Entities.Applications;
using TalentAI.Domain.Entities.Identity;
using TalentAI.Domain.Entities.Metadata;
using TalentAI.Domain.Entities.Resumes;

namespace TalentAI.Domain.Entities.Profiles;

public class Candidate : BaseEntity
{
    public Guid UserId { get; set; }

    public int? ProvinceId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public DateOnly? DateOfBirth { get; set; }

    public string? AvatarUrl { get; set; }

    public User User { get; set; } = null!;

    public Province? Province { get; set; }

    public ICollection<CandidateSkill> CandidateSkills { get; set; }
        = new List<CandidateSkill>();

    public ICollection<Education> Educations { get; set; }
        = new List<Education>();

    public ICollection<Certificate> Certificates { get; set; }
        = new List<Certificate>();

    public ICollection<Experience> Experiences { get; set; }
        = new List<Experience>();

    public ICollection<Resume> Resumes { get; set; }
        = new List<Resume>();

    public ICollection<JobApplication> JobApplications { get; set; }
        = new List<JobApplication>();
}
