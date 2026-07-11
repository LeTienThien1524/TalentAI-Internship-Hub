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

public class AIMatchScoreRepository
    : GenericRepository<AIMatchScore>,
      IAIMatchScoreRepository
{
    public AIMatchScoreRepository(
        TalentAIDbContext context)
        : base(context)
    {
    }

    public async Task<AIMatchScore?>
        GetByApplicationIdAsync(
            Guid applicationId)
    {
        return await _context.AIMatchScores
            .FirstOrDefaultAsync(
                x => x.JobApplicationId
                    == applicationId);
    }
}
