using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAI.Domain.Entities.Resumes;

namespace TalentAI.Infrastructure.Configurations;

public class AIParsedResumeConfiguration
    : IEntityTypeConfiguration<AIParsedResume>
{
    public void Configure(EntityTypeBuilder<AIParsedResume> builder)
    {
        builder.ToTable("AIParsedResumes");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Resume)
               .WithOne(x => x.AIParsedResume)
               .HasForeignKey<AIParsedResume>(x => x.ResumeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
