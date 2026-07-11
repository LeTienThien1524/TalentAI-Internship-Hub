using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Common;
using TalentAI.Domain.Entities.Applications;
using TalentAI.Domain.Entities.Metadata;
using TalentAI.Domain.Entities.Profiles;
using TalentAI.Domain.Enums;

namespace TalentAI.Domain.Entities.Jobs;

public class JobPosting : BaseEntity
{
    public Guid CompanyId { get; set; }

    public int JobCategoryId { get; set; }

    public int ProvinceId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Requirements { get; set; } = string.Empty;

    public string? Benefits { get; set; }

    public int InternshipDurationMonths { get; set; }

    public decimal? SalaryFrom { get; set; }

    public decimal? SalaryTo { get; set; }

    public DateTime Deadline { get; set; }

    public WorkType WorkType { get; set; }

    public JobPostingStatus Status { get; set; }

    public Company Company { get; set; } = null!;

    public JobCategory JobCategory { get; set; } = null!;

    public Province Province { get; set; } = null!;

    public ICollection<JobSkill> JobSkills { get; set; }
        = new List<JobSkill>();

    public ICollection<JobApplication> JobApplications { get; set; }
        = new List<JobApplication>();
}
