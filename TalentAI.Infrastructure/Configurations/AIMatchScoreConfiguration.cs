using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAI.Domain.Entities.Applications;

namespace TalentAI.Infrastructure.Configurations;

public class AIMatchScoreConfiguration
    : IEntityTypeConfiguration<AIMatchScore>
{
    public void Configure(EntityTypeBuilder<AIMatchScore> builder)
    {
        builder.ToTable("AIMatchScores");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.MatchPercentage)
               .HasPrecision(5, 2);

        builder.HasOne(x => x.JobApplication)
               .WithOne(x => x.AIMatchScore)
               .HasForeignKey<AIMatchScore>(x => x.JobApplicationId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
