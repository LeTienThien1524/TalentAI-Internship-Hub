using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAI.Domain.Entities.Resumes;

namespace TalentAI.Infrastructure.Configurations;

public class ResumeConfiguration
    : IEntityTypeConfiguration<Resume>
{
    public void Configure(EntityTypeBuilder<Resume> builder)
    {
        builder.ToTable("Resumes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FileName)
               .HasMaxLength(256)
               .IsRequired();

        builder.Property(x => x.FilePath)
               .HasMaxLength(512)
               .IsRequired();

        builder.HasOne(x => x.Candidate)
               .WithMany(x => x.Resumes)
               .HasForeignKey(x => x.CandidateId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
