using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.System;

namespace TalentAI.Domain.Repositories;

public interface INotificationRepository
    : IGenericRepository<Notification>
{
    Task<IEnumerable<Notification>>
        GetByUserIdAsync(Guid userId);
}
