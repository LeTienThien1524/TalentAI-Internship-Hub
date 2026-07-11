using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Entities.Identity;

namespace TalentAI.Domain.Repositories;

public interface IPasswordResetTokenRepository
    : IGenericRepository<PasswordResetToken>
{
    Task<PasswordResetToken?> GetByTokenAsync(string token);

    Task<IEnumerable<PasswordResetToken>>
        GetByUserIdAsync(Guid userId);

    Task RevokeAllAsync(Guid userId);
}
