using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Infrastructure.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CompanyName)
               .HasMaxLength(256)
               .IsRequired();

        builder.Property(x => x.TaxCode)
               .HasMaxLength(20);

        builder.Property(x => x.Website)
               .HasMaxLength(256);

        builder.Property(x => x.LogoUrl)
               .HasMaxLength(512);

        builder.HasOne(x => x.User)
               .WithOne(x => x.Company)
               .HasForeignKey<Company>(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Province)
               .WithMany(x => x.Companies)
               .HasForeignKey(x => x.ProvinceId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
