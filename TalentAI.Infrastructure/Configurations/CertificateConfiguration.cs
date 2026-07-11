using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Infrastructure.Configurations;

public class CertificateConfiguration
    : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.ToTable("Certificates");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(x => x.Issuer)
               .HasMaxLength(200)
               .IsRequired();

        builder.HasOne(x => x.Candidate)
               .WithMany(x => x.Certificates)
               .HasForeignKey(x => x.CandidateId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
