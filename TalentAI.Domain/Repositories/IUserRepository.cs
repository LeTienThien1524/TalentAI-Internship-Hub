using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Identity;

namespace TalentAI.Domain.Repositories;

public interface IUserRepository
    : IGenericRepository<User>
{
    Task<User?> GetByIdWithRolesAsync(Guid id);

    Task<User?> GetByEmailAsync(string email);

    Task<bool> ExistsByEmailAsync(string email);

    Task<IEnumerable<User>> GetActiveUsersAsync();

    Task<IEnumerable<User>> GetDeletedUsersAsync();
}
