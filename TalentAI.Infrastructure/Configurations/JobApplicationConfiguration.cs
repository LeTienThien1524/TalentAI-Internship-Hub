using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentAI.Domain.Entities.Applications;

namespace TalentAI.Infrastructure.Configurations;

public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.ToTable("JobApplications");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Candidate)
               .WithMany(x => x.JobApplications)
               .HasForeignKey(x => x.CandidateId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.JobPosting)
               .WithMany(x => x.JobApplications)
               .HasForeignKey(x => x.JobPostingId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Resume)
               .WithMany(x => x.JobApplications)
               .HasForeignKey(x => x.ResumeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.CandidateId,
            x.JobPostingId
        }).IsUnique();
    }
}
