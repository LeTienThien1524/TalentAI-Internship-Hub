using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Identity;

namespace TalentAI.Domain.Repositories;

public interface IRefreshTokenRepository
    : IGenericRepository<RefreshToken>
{
    Task<RefreshToken?> GetByTokenAsync(string token);

    Task<List<RefreshToken>> GetByUserIdAsync(Guid userId);

    Task<List<RefreshToken>> GetValidTokensByUserIdAsync(Guid userId);

    Task RevokeAllAsync(Guid userId);
}
