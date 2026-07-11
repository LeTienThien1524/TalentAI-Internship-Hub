using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobPostings.DTOs;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.JobPostings.Queries.GetJobPostingList;

public class GetJobPostingListQueryHandler
    : IRequestHandler<
        GetJobPostingListQuery,
        Result<List<JobPostingDto>>>
{
    private readonly IJobPostingRepository _jobPostingRepository;

    public GetJobPostingListQueryHandler(
        IJobPostingRepository jobPostingRepository)
    {
        _jobPostingRepository = jobPostingRepository;
    }

    public async Task<Result<List<JobPostingDto>>> Handle(
        GetJobPostingListQuery request,
        CancellationToken cancellationToken)
    {
        var jobs =
            await _jobPostingRepository.GetAllAsync();

        var result = jobs
            .Select(job => new JobPostingDto
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
            })
            .ToList();

        return Result<List<JobPostingDto>>
            .Success(result);
    }
}
