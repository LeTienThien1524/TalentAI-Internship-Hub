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

public class ApplicationHistoryRepository
    : GenericRepository<ApplicationHistory>,
      IApplicationHistoryRepository
{
    public ApplicationHistoryRepository(
        TalentAIDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<ApplicationHistory>>
        GetByApplicationIdAsync(Guid applicationId)
    {
        return await _context.ApplicationHistories
            .Where(x =>
                x.JobApplicationId == applicationId)
            .OrderByDescending(x =>
                x.ChangedAt)
            .ToListAsync();
    }
}
