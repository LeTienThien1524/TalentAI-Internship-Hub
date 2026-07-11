using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Enums;

namespace TalentAI.Application.Features.JobPostings.DTOs;

public class JobPostingDto
{
    public Guid Id { get; set; }

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
}
