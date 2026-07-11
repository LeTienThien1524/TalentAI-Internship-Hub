using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Jobs;

namespace TalentAI.Domain.Repositories;

public interface IJobPostingRepository
    : IGenericRepository<JobPosting>
{
    Task<IEnumerable<JobPosting>> GetActiveJobsAsync();

    Task<IEnumerable<JobPosting>> GetByCompanyIdAsync(
        Guid companyId);
}
