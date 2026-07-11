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

public class UserRoleRepository
    : IUserRoleRepository
{
    private readonly TalentAIDbContext _context;

    public UserRoleRepository(
        TalentAIDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserRole>>
        GetByUserIdAsync(Guid userId)
    {
        return await _context.UserRoles
            .Include(x => x.Role)
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(
        Guid userId,
        Guid roleId)
    {
        return await _context.UserRoles
            .AnyAsync(x =>
                x.UserId == userId &&
                x.RoleId == roleId);
    }

    public async Task AddAsync(
        UserRole userRole)
    {
        await _context.UserRoles
            .AddAsync(userRole);
    }

    public async Task<List<Role>> GetRolesByUserIdAsync(Guid userId)
    {
        return await _context.UserRoles
            .Where(x => x.UserId == userId)
            .Select(x => x.Role)
            .ToListAsync();
    }

    public async Task AssignRoleAsync(Guid userId, Guid roleId)
    {
        await _context.UserRoles.AddAsync(
            new UserRole
            {
                UserId = userId,
                RoleId = roleId
            });
    }

    public Task RemoveAsync(UserRole userRole)
    {
        _context.UserRoles.Remove(userRole);

        return Task.CompletedTask;
    }
}
