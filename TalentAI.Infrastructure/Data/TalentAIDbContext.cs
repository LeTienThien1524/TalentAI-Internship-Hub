using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using TalentAI.Domain.Common;
using TalentAI.Domain.Entities.Applications;
using TalentAI.Domain.Entities.Identity;
using TalentAI.Domain.Entities.Jobs;
using TalentAI.Domain.Entities.Metadata;
using TalentAI.Domain.Entities.Profiles;
using TalentAI.Domain.Entities.Resumes;
using TalentAI.Domain.Entities.System;

namespace TalentAI.Infrastructure.Data;

public class TalentAIDbContext : DbContext
{
    public TalentAIDbContext(
        DbContextOptions<TalentAIDbContext> options)
        : base(options)
    {
    }

    #region Identity

    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<UserRole> UserRoles => Set<UserRole>();

    #endregion

    #region Metadata

    public DbSet<Province> Provinces => Set<Province>();

    public DbSet<JobCategory> JobCategories => Set<JobCategory>();

    public DbSet<Skill> Skills => Set<Skill>();

    #endregion

    #region Candidate

    public DbSet<Candidate> Candidates => Set<Candidate>();

    public DbSet<CandidateSkill> CandidateSkills => Set<CandidateSkill>();

    public DbSet<Education> Educations => Set<Education>();

    public DbSet<Certificate> Certificates => Set<Certificate>();

    public DbSet<Experience> Experiences => Set<Experience>();

    public DbSet<Resume> Resumes => Set<Resume>();

    #endregion

    #region Company

    public DbSet<Company> Companies => Set<Company>();

    #endregion

    #region Recruitment

    public DbSet<JobPosting> JobPostings => Set<JobPosting>();

    public DbSet<JobSkill> JobSkills => Set<JobSkill>();

    public DbSet<JobApplication> JobApplications => Set<JobApplication>();

    public DbSet<ApplicationHistory> ApplicationHistories => Set<ApplicationHistory>();

    public DbSet<Interview> Interviews => Set<Interview>();

    #endregion

    #region AI

    public DbSet<AIParsedResume> AIParsedResumes => Set<AIParsedResume>();

    public DbSet<AIMatchScore> AIMatchScores => Set<AIMatchScore>();

    #endregion

    #region System

    public DbSet<Notification> Notifications => Set<Notification>();

    #endregion

    #region AccessToken - RefreshToken

    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    #endregion

    #region PasswordResetToken

    public DbSet<PasswordResetToken> PasswordResetTokens => Set<PasswordResetToken>();

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(TalentAIDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.IsDeleted = false;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
