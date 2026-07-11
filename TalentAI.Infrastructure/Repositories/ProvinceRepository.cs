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

public class ProvinceRepository : IProvinceRepository
{
    private readonly TalentAIDbContext _context;

    public ProvinceRepository(TalentAIDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Province>> GetAllAsync()
    {
        return await _context.Provinces
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Province?> GetByIdAsync(int id)
    {
        return await _context.Provinces
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Provinces
            .AnyAsync(x => x.Name == name);
    }

    public async Task AddAsync(Province province)
    {
        await _context.Provinces.AddAsync(province);
    }

    public void Update(Province province)
    {
        _context.Provinces.Update(province);
    }

    public void Delete(Province province)
    {
        _context.Provinces.Remove(province);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
