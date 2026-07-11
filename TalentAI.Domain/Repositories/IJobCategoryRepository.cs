using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Metadata;

namespace TalentAI.Domain.Repositories;

public interface IJobCategoryRepository
{
    Task<IEnumerable<JobCategory>> GetAllAsync();

    Task<JobCategory?> GetByIdAsync(int id);

    Task<bool> ExistsByNameAsync(string name);

    Task AddAsync(JobCategory jobCategory);

    void Update(JobCategory jobCategory);

    void Delete(JobCategory jobCategory);

    Task SaveChangesAsync();
}
