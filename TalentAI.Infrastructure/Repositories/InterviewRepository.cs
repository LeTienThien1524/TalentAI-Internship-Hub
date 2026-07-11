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

public class InterviewRepository
    : GenericRepository<Interview>,
      IInterviewRepository
{
    public InterviewRepository(
        TalentAIDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Interview>>
        GetByJobApplicationIdAsync(
            Guid jobApplicationId)
    {
        return await _context.Interviews
            .Where(x =>
                x.JobApplicationId
                == jobApplicationId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Interview>>
        GetByCandidateIdAsync(
            Guid candidateId)
    {
        return await _context.Interviews
            .Include(x => x.JobApplication)
            .Where(x =>
                x.JobApplication.CandidateId
                == candidateId)
            .ToListAsync();
    }
}
