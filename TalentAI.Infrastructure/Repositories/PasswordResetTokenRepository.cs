using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TalentAI.Domain.Entities.Identity;
using TalentAI.Domain.Repositories;
using TalentAI.Infrastructure.Data;

namespace TalentAI.Infrastructure.Repositories;

public class PasswordResetTokenRepository
    : GenericRepository<PasswordResetToken>,
      IPasswordResetTokenRepository
{
    public PasswordResetTokenRepository(
        TalentAIDbContext context)
        : base(context)
    {
    }

    public async Task<PasswordResetToken?>
        GetByTokenAsync(string token)
    {
        return await _context.PasswordResetTokens
            .Include(x => x.User)
            .FirstOrDefaultAsync(x =>
                x.Token == token &&
                !x.IsUsed &&
                !x.IsDeleted);
    }

    public async Task<IEnumerable<PasswordResetToken>>
        GetByUserIdAsync(Guid userId)
    {
        return await _context.PasswordResetTokens
            .Where(x => x.UserId == userId && !x.IsDeleted)
            .ToListAsync();
    }

    public async Task RevokeAllAsync(Guid userId)
    {
        var tokens = await _context.PasswordResetTokens
            .Where(x =>
                x.UserId == userId &&
                !x.IsUsed)
            .ToListAsync();

        foreach (var token in tokens)
        {
            token.IsUsed = true;
        }
    }
}
