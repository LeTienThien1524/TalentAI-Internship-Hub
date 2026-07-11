using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TalentAI.Domain.Entities.Metadata;
using TalentAI.Domain.Repositories;
using TalentAI.Infrastructure.Data;

namespace TalentAI.Infrastructure.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly TalentAIDbContext _context;

    public SkillRepository(TalentAIDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Skill>> GetAllAsync()
    {
        return await _context.Skills
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Skill?> GetByIdAsync(int id)
    {
        return await _context.Skills
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Skills
            .AnyAsync(x => x.Name == name);
    }

    public async Task AddAsync(Skill skill)
    {
        await _context.Skills.AddAsync(skill);
    }

    public void Update(Skill skill)
    {
        _context.Skills.Update(skill);
    }

    public void Delete(Skill skill)
    {
        _context.Skills.Remove(skill);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
