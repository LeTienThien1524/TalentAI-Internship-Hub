using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Domain.Repositories;

public interface ICertificateRepository
{
    Task<List<Certificate>>
        GetByCandidateIdAsync(Guid candidateId);

    Task<Certificate?>
        GetByIdAsync(Guid id);

    Task AddAsync(Certificate certificate);

    void Update(Certificate certificate);

    void Delete(Certificate certificate);

    Task SaveChangesAsync();
}
