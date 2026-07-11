using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TalentAI.Domain.Entities.Applications;
using TalentAI.Domain.Repositories;
using TalentAI.Infrastructure.Data;

namespace TalentAI.Infrastructure.Repositories;

public class JobApplicationRepository
    : GenericRepository<JobApplication>,
      IJobApplicationRepository
{
    public JobApplicationRepository(
        TalentAIDbContext context)
        : base(context)
    {
    }

    public async Task<bool> HasAppliedAsync(
        Guid candidateId,
        Guid jobPostingId)
    {
        return await _context.JobApplications
            .AnyAsync(x =>
                x.CandidateId == candidateId
                && x.JobPostingId == jobPostingId);
    }

    public async Task<IEnumerable<JobApplication>>
        GetByCandidateIdAsync(Guid candidateId)
    {
        return await _context.JobApplications
            .Include(x => x.JobPosting)
            .Include(x => x.Resume)
            .Where(x =>
                x.CandidateId == candidateId)
            .OrderByDescending(x => x.AppliedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<JobApplication>>
        GetByJobPostingIdAsync(Guid jobPostingId)
    {
        return await _context.JobApplications
            .Include(x => x.Candidate)
            .Include(x => x.Resume)
            .Where(x =>
                x.JobPostingId == jobPostingId)
            .OrderByDescending(x => x.AppliedAt)
            .ToListAsync();
    }
}
