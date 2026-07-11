using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Domain.Repositories;

public interface IEducationRepository
{
    Task<List<Education>>
        GetByCandidateIdAsync(Guid candidateId);

    Task<Education?>
        GetByIdAsync(Guid id);

    Task AddAsync(Education education);

    void Update(Education education);

    void Delete(Education education);

    Task SaveChangesAsync();
}
