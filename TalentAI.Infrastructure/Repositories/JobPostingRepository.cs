using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TalentAI.Domain.Entities.Jobs;
using TalentAI.Domain.Enums;
using TalentAI.Domain.Repositories;
using TalentAI.Infrastructure.Data;

namespace TalentAI.Infrastructure.Repositories;

public class JobPostingRepository
    : GenericRepository<JobPosting>,
      IJobPostingRepository
{
    public JobPostingRepository(
        TalentAIDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<JobPosting>>
        GetActiveJobsAsync()
    {
        return await _context.JobPostings
            .Where(x =>
                x.Status == JobPostingStatus.Published
                && x.Deadline > DateTime.UtcNow
                && !x.IsDeleted)
            .ToListAsync();
    }

    public async Task<IEnumerable<JobPosting>>
        GetByCompanyIdAsync(Guid companyId)
    {
        return await _context.JobPostings
            .Where(x =>
                x.CompanyId == companyId
                && !x.IsDeleted)
            .ToListAsync();
    }
}
