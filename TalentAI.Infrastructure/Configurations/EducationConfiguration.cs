using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Infrastructure.Configurations;

public class EducationConfiguration
    : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.ToTable("Educations");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.University)
               .HasMaxLength(256)
               .IsRequired();

        builder.Property(x => x.Major)
               .HasMaxLength(200);

        builder.Property(x => x.Degree)
               .HasMaxLength(100);

        builder.Property(x => x.GPA)
               .HasPrecision(3, 2);

        builder.HasOne(x => x.Candidate)
               .WithMany(x => x.Educations)
               .HasForeignKey(x => x.CandidateId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
