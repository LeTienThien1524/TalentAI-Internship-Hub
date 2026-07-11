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

public class RefreshTokenRepository
    : GenericRepository<RefreshToken>,
      IRefreshTokenRepository
{
    public RefreshTokenRepository(
        TalentAIDbContext context)
        : base(context)
    {
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        return await _context.RefreshTokens
            .Include(x => x.User)
            .FirstOrDefaultAsync(x =>
                x.Token == token &&
                !x.IsRevoked &&
                !x.IsDeleted);
    }

    public async Task<List<RefreshToken>> GetByUserIdAsync(Guid userId)
    {
        return await _context.RefreshTokens
            .Where(x =>
                x.UserId == userId &&
                !x.IsDeleted)
            .ToListAsync();
    }

    public async Task<List<RefreshToken>> GetValidTokensByUserIdAsync(Guid userId)
    {
        return await _context.RefreshTokens
            .Where(x =>
                x.UserId == userId &&
                x.RevokedAt == null &&
                x.ExpiresAt > DateTime.UtcNow)
            .ToListAsync();
    }

    public async Task RevokeAllAsync(Guid userId)
    {
        var tokens =
            await GetByUserIdAsync(userId);

        foreach (var token in tokens)
        {
            token.IsRevoked = true;
            token.RevokedAt = DateTime.UtcNow;
        }
    }
}
