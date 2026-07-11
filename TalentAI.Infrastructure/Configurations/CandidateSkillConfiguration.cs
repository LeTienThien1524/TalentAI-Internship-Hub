using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Infrastructure.Configurations;

public class CandidateSkillConfiguration
    : IEntityTypeConfiguration<CandidateSkill>
{
    public void Configure(EntityTypeBuilder<CandidateSkill> builder)
    {
        builder.ToTable("CandidateSkills");

        builder.HasKey(x => new
        {
            x.CandidateId,
            x.SkillId
        });

        builder.HasOne(x => x.Candidate)
               .WithMany(x => x.CandidateSkills)
               .HasForeignKey(x => x.CandidateId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Skill)
               .WithMany(x => x.CandidateSkills)
               .HasForeignKey(x => x.SkillId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
