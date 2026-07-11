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

public class EducationRepository
    : IEducationRepository
{
    private readonly TalentAIDbContext _context;

    public EducationRepository(
        TalentAIDbContext context)
    {
        _context = context;
    }

    public async Task<List<Education>>
        GetByCandidateIdAsync(Guid candidateId)
    {
        return await _context.Educations
            .Where(x => x.CandidateId == candidateId)
            .ToListAsync();
    }

    public async Task<Education?>
        GetByIdAsync(Guid id)
    {
        return await _context.Educations
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Education education)
    {
        await _context.Educations.AddAsync(education);
    }

    public void Update(Education education)
    {
        _context.Educations.Update(education);
    }

    public void Delete(Education education)
    {
        _context.Educations.Remove(education);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
