using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAI.Domain.Entities.Jobs;

namespace TalentAI.Infrastructure.Configurations;

public class JobPostingConfiguration
    : IEntityTypeConfiguration<JobPosting>
{
    public void Configure(EntityTypeBuilder<JobPosting> builder)
    {
        builder.ToTable("JobPostings");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
               .HasMaxLength(256)
               .IsRequired();

        builder.Property(x => x.SalaryFrom)
               .HasPrecision(18, 2);

        builder.Property(x => x.SalaryTo)
               .HasPrecision(18, 2);

        builder.HasOne(x => x.Company)
               .WithMany(x => x.JobPostings)
               .HasForeignKey(x => x.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.JobCategory)
               .WithMany(x => x.JobPostings)
               .HasForeignKey(x => x.JobCategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Province)
               .WithMany(x => x.JobPostings)
               .HasForeignKey(x => x.ProvinceId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
