using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Applications;

namespace TalentAI.Domain.Repositories;

public interface IJobApplicationRepository
    : IGenericRepository<JobApplication>
{
    Task<bool> HasAppliedAsync(
        Guid candidateId,
        Guid jobPostingId);

    Task<IEnumerable<JobApplication>>
        GetByCandidateIdAsync(Guid candidateId);

    Task<IEnumerable<JobApplication>>
        GetByJobPostingIdAsync(Guid jobPostingId);
}
