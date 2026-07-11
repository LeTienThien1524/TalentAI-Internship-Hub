using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAI.Domain.Entities.Applications;

namespace TalentAI.Infrastructure.Configurations;

public class ApplicationHistoryConfiguration
    : IEntityTypeConfiguration<ApplicationHistory>
{
    public void Configure(EntityTypeBuilder<ApplicationHistory> builder)
    {
        builder.ToTable("ApplicationHistories");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.JobApplication)
               .WithMany(x => x.ApplicationHistories)
               .HasForeignKey(x => x.JobApplicationId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ChangedByUser)
               .WithMany()
               .HasForeignKey(x => x.ChangedByUserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
