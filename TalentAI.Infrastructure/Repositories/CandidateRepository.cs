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

public class CandidateRepository : ICandidateRepository
{
    private readonly TalentAIDbContext _context;

    public CandidateRepository(TalentAIDbContext context)
    {
        _context = context;
    }

    public async Task<Candidate?> GetByUserIdAsync(Guid userId)
    {
        return await _context.Candidates
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task<bool> ExistsByUserIdAsync(Guid userId)
    {
        return await _context.Candidates
            .AnyAsync(x => x.UserId == userId);
    }

    public async Task<Candidate?> GetByIdAsync(Guid id)
        => await _context.Candidates.FindAsync(id);

    public async Task<IEnumerable<Candidate>> GetAllAsync()
        => await _context.Candidates.ToListAsync();

    public async Task AddAsync(Candidate entity)
        => await _context.Candidates.AddAsync(entity);

    public void Add(Candidate candidate)
        => _context.Candidates.Add(candidate);

    public void Update(Candidate entity)
        => _context.Candidates.Update(entity);

    public void Delete(Candidate entity)
        => _context.Candidates.Remove(entity);

    public Task AddRangeAsync(IEnumerable<Candidate> entities)
    {
        _context.Candidates.AddRange(entities);
        return Task.CompletedTask;
    }
}
