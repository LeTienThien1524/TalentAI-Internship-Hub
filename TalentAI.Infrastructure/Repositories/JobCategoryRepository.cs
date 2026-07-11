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

public class JobCategoryRepository : IJobCategoryRepository
{
    private readonly TalentAIDbContext _context;

    public JobCategoryRepository(TalentAIDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<JobCategory>> GetAllAsync()
    {
        return await _context.JobCategories
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<JobCategory?> GetByIdAsync(int id)
    {
        return await _context.JobCategories
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.JobCategories
            .AnyAsync(x => x.Name == name);
    }

    public async Task AddAsync(JobCategory jobCategory)
    {
        await _context.JobCategories.AddAsync(jobCategory);
    }

    public void Update(JobCategory jobCategory)
    {
        _context.JobCategories.Update(jobCategory);
    }

    public void Delete(JobCategory jobCategory)
    {
        _context.JobCategories.Remove(jobCategory);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
