using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TalentAI.Domain.Entities.Profiles;
using TalentAI.Domain.Repositories;
using TalentAI.Infrastructure.Data;

namespace TalentAI.Infrastructure.Repositories;

public class CompanyRepository
    : GenericRepository<Company>,
      ICompanyRepository
{
    public CompanyRepository(
        TalentAIDbContext context)
        : base(context)
    {
    }

    public async Task<Company?> GetByUserIdAsync(
        Guid userId)
    {
        return await _context.Companies
            .FirstOrDefaultAsync(x =>
                x.UserId == userId);
    }

    public async Task<bool> ExistsByUserIdAsync(
        Guid userId)
    {
        return await _context.Companies
            .AnyAsync(x =>
                x.UserId == userId);
    }
}
