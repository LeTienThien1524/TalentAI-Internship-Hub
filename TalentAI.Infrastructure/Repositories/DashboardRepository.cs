using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TalentAI.Domain.Repositories;
using TalentAI.Infrastructure.Data;

namespace TalentAI.Infrastructure.Repositories;

public class DashboardRepository
    : IDashboardRepository
{
    private readonly TalentAIDbContext _context;

    public DashboardRepository(
        TalentAIDbContext context)
    {
        _context = context;
    }

    public async Task<int>
        GetTotalCandidatesAsync()
        => await _context.Candidates.CountAsync();

    public async Task<int>
        GetTotalCompaniesAsync()
        => await _context.Companies.CountAsync();

    public async Task<int>
        GetTotalJobsAsync()
        => await _context.JobPostings.CountAsync();

    public async Task<int>
        GetTotalApplicationsAsync()
        => await _context.JobApplications.CountAsync();

    public async Task<int>
        GetTotalInterviewsAsync()
        => await _context.Interviews.CountAsync();
}
