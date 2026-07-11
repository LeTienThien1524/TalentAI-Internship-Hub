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

public class CertificateRepository
    : ICertificateRepository
{
    private readonly TalentAIDbContext _context;

    public CertificateRepository(
        TalentAIDbContext context)
    {
        _context = context;
    }

    public async Task<List<Certificate>>
        GetByCandidateIdAsync(Guid candidateId)
    {
        return await _context.Certificates
            .Where(x => x.CandidateId == candidateId)
            .ToListAsync();
    }

    public async Task<Certificate?>
        GetByIdAsync(Guid id)
    {
        return await _context.Certificates
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(
        Certificate certificate)
    {
        await _context.Certificates
            .AddAsync(certificate);
    }

    public void Update(
        Certificate certificate)
    {
        _context.Certificates
            .Update(certificate);
    }

    public void Delete(
        Certificate certificate)
    {
        _context.Certificates
            .Remove(certificate);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
