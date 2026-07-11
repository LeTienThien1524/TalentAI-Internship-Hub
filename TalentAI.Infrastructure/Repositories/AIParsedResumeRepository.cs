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

public class AIParsedResumeRepository
    : GenericRepository<AIParsedResume>,
      IAIParsedResumeRepository
{
    public AIParsedResumeRepository(
        TalentAIDbContext context)
        : base(context)
    {
    }

    public async Task<AIParsedResume?>
        GetByResumeIdAsync(Guid resumeId)
    {
        return await _context.AIParsedResumes
            .FirstOrDefaultAsync(
                x => x.ResumeId == resumeId);
    }
}
