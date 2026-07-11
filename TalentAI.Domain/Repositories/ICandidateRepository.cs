using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Domain.Repositories;

public interface ICandidateRepository
    : IGenericRepository<Candidate>
{
    Task<Candidate?> GetByUserIdAsync(Guid userId);

    Task<bool> ExistsByUserIdAsync(Guid userId);

    void Add(Candidate candidate);
}
