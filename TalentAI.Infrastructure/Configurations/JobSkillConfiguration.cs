using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAI.Domain.Entities.Jobs;

namespace TalentAI.Infrastructure.Configurations;

public class JobSkillConfiguration : IEntityTypeConfiguration<JobSkill>
{
    public void Configure(EntityTypeBuilder<JobSkill> builder)
    {
        builder.ToTable("JobSkills");

        builder.HasKey(x => new
        {
            x.JobPostingId,
            x.SkillId
        });

        builder.HasOne(x => x.JobPosting)
               .WithMany(x => x.JobSkills)
               .HasForeignKey(x => x.JobPostingId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Skill)
               .WithMany(x => x.JobSkills)
               .HasForeignKey(x => x.SkillId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
