using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Applications;

namespace TalentAI.Domain.Repositories;

public interface IAIMatchScoreRepository
    : IGenericRepository<AIMatchScore>
{
    Task<AIMatchScore?>
        GetByApplicationIdAsync(Guid applicationId);
}
