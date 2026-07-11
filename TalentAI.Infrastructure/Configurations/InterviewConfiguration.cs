using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAI.Domain.Entities.Applications;

namespace TalentAI.Infrastructure.Configurations;

public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
{
    public void Configure(EntityTypeBuilder<Interview> builder)
    {
        builder.ToTable("Interviews");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.LocationOrLink)
               .HasMaxLength(512)
               .IsRequired();

        builder.Property(x => x.InterviewerName)
               .HasMaxLength(256)
               .IsRequired();

        builder.HasOne(x => x.JobApplication)
               .WithMany(x => x.Interviews)
               .HasForeignKey(x => x.JobApplicationId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
