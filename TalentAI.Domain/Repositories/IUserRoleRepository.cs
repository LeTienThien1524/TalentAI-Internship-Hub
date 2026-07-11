using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Identity;

namespace TalentAI.Domain.Repositories;

public interface IUserRoleRepository
{
    Task<List<UserRole>> GetByUserIdAsync(Guid userId);

    Task<bool> ExistsAsync(Guid userId, Guid roleId);

    Task AddAsync(UserRole userRole);

    Task RemoveAsync(UserRole userRole);

    Task<List<Role>> GetRolesByUserIdAsync(Guid userId);

    Task AssignRoleAsync(Guid userId, Guid roleId);
}
