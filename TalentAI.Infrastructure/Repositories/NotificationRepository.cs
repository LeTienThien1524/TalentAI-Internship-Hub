using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TalentAI.Domain.Entities.System;
using TalentAI.Domain.Repositories;
using TalentAI.Infrastructure.Data;

namespace TalentAI.Infrastructure.Repositories;

public class NotificationRepository
    : GenericRepository<Notification>,
      INotificationRepository
{
    public NotificationRepository(
        TalentAIDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Notification>>
        GetByUserIdAsync(Guid userId)
    {
        return await _context.Notifications
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }
}
