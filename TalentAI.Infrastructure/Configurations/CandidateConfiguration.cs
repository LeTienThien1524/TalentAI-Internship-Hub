using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Infrastructure.Configurations;

public class CandidateConfiguration
    : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.ToTable("Candidates");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FullName)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(x => x.AvatarUrl)
               .HasMaxLength(512);

        builder.HasOne(x => x.User)
               .WithOne(x => x.Candidate)
               .HasForeignKey<Candidate>(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Province)
               .WithMany(x => x.Candidates)
               .HasForeignKey(x => x.ProvinceId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
