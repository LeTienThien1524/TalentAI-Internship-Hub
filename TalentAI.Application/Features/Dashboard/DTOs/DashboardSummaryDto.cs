using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAI.Application.Features.Dashboard.DTOs;

public class DashboardSummaryDto
{
    public int TotalCandidates { get; set; }

    public int TotalCompanies { get; set; }

    public int TotalJobs { get; set; }

    public int TotalApplications { get; set; }

    public int TotalInterviews { get; set; }
}
