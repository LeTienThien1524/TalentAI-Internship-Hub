using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Entities.Identity;
using TalentAI.Domain.Repositories;
using TalentAI.Infrastructure.Data;

namespace TalentAI.Infrastructure.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(TalentAIDbContext context)
        : base(context)
    {
    }

    public async Task<Role?> GetByNameAsync(string name)
    {
        return await _context.Roles
            .FirstOrDefaultAsync(x => x.NormalizedName == name.ToUpper());
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Roles
            .AnyAsync(x => x.NormalizedName == name.ToUpper() && !x.IsDeleted);
    }
}
