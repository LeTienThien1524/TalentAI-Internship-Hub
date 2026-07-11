using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Common;
using TalentAI.Domain.Entities.Identity;
using TalentAI.Domain.Entities.Jobs;
using TalentAI.Domain.Entities.Metadata;

namespace TalentAI.Domain.Entities.Profiles;

public class Company : BaseEntity
{
    public Guid UserId { get; set; }

    public int? ProvinceId { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public string? TaxCode { get; set; }

    public string? Website { get; set; }

    public string? LogoUrl { get; set; }

    public string? Description { get; set; }

    public bool IsVerified { get; set; }

    public User User { get; set; } = null!;

    public Province Province { get; set; } = null!;

    public ICollection<JobPosting> JobPostings { get; set; }
        = new List<JobPosting>();
}
