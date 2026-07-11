using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Applications;

namespace TalentAI.Domain.Repositories;

public interface IInterviewRepository
    : IGenericRepository<Interview>
{
    Task<IEnumerable<Interview>>
        GetByJobApplicationIdAsync(
            Guid jobApplicationId);

    Task<IEnumerable<Interview>>
        GetByCandidateIdAsync(
            Guid candidateId);
}
