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

public class ExperienceRepository
    : IExperienceRepository
{
    private readonly TalentAIDbContext _context;

    public ExperienceRepository(
        TalentAIDbContext context)
    {
        _context = context;
    }

    public async Task<List<Experience>>
        GetByCandidateIdAsync(Guid candidateId)
    {
        return await _context.Experiences
            .Where(x => x.CandidateId == candidateId)
            .ToListAsync();
    }

    public async Task<Experience?>
        GetByIdAsync(Guid id)
    {
        return await _context.Experiences
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(
        Experience experience)
    {
        await _context.Experiences
            .AddAsync(experience);
    }

    public void Update(
        Experience experience)
    {
        _context.Experiences
            .Update(experience);
    }

    public void Delete(
        Experience experience)
    {
        _context.Experiences
            .Remove(experience);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}