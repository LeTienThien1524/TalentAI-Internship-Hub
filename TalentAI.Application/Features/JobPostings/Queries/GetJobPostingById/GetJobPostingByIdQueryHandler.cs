using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobPostings.DTOs;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.JobPostings.Queries.GetJobPostingById;

public class GetJobPostingByIdQueryHandler
    : IRequestHandler<
        GetJobPostingByIdQuery,
        Result<JobPostingDto>>
{
    private readonly IJobPostingRepository _jobPostingRepository;

    public GetJobPostingByIdQueryHandler(
        IJobPostingRepository jobPostingRepository)
    {
        _jobPostingRepository = jobPostingRepository;
    }

    public async Task<Result<JobPostingDto>> Handle(
        GetJobPostingByIdQuery request,
        CancellationToken cancellationToken)
    {
        var job = await _jobPostingRepository
            .GetByIdAsync(request.Id);

        if (job == null)
        {
            return Result<JobPostingDto>
                .Failure("Job posting not found");
        }

        return Result<JobPostingDto>.Success(
            new JobPostingDto
            {
                Id = job.Id,
                CompanyId = job.CompanyId,
                JobCategoryId = job.JobCategoryId,
                ProvinceId = job.ProvinceId,
                Title = job.Title,
                Description = job.Description,
                Requirements = job.Requirements,
                Benefits = job.Benefits,
                InternshipDurationMonths = job.InternshipDurationMonths,
                SalaryFrom = job.SalaryFrom,
                SalaryTo = job.SalaryTo,
                Deadline = job.Deadline,
                WorkType = job.WorkType,
                Status = job.Status
            });
    }
}
