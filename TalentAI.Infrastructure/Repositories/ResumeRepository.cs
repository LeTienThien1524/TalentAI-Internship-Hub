using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TalentAI.Domain.Entities.Resumes;
using TalentAI.Domain.Repositories;
using TalentAI.Infrastructure.Data;

namespace TalentAI.Infrastructure.Repositories;

public class ResumeRepository
    : GenericRepository<Resume>,
      IResumeRepository
{
    public ResumeRepository(
        TalentAIDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Resume>>
        GetByCandidateIdAsync(Guid candidateId)
    {
        return await _context.Resumes
            .Where(x =>
                x.CandidateId == candidateId)
            .OrderByDescending(x =>
                x.UploadedAt)
            .ToListAsync();
    }
}
