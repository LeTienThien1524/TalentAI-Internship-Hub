using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Domain.Repositories;

public interface IExperienceRepository
{
    Task<List<Experience>>
        GetByCandidateIdAsync(Guid candidateId);

    Task<Experience?>
        GetByIdAsync(Guid id);

    Task AddAsync(Experience experience);

    void Update(Experience experience);

    void Delete(Experience experience);

    Task SaveChangesAsync();
}