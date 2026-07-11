using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Resumes;

namespace TalentAI.Domain.Repositories;

public interface IResumeRepository
    : IGenericRepository<Resume>
{
    Task<IEnumerable<Resume>>
        GetByCandidateIdAsync(Guid candidateId);
}
