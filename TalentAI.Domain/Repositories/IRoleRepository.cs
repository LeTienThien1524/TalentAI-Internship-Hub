using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Identity;

namespace TalentAI.Domain.Repositories;

public interface IRoleRepository
    : IGenericRepository<Role>
{
    Task<Role?> GetByNameAsync(string name);

    Task<bool> ExistsByNameAsync(string name);
}
