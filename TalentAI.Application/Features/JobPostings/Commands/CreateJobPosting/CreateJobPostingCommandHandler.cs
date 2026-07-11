using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobPostings.DTOs;
using TalentAI.Domain.Entities.Jobs;
using TalentAI.Domain.Enums;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.JobPostings.Commands.CreateJobPosting;

public class CreateJobPostingCommandHandler
    : IRequestHandler<CreateJobPostingCommand,
        Result<JobPostingDto>>
{
    private readonly IJobPostingRepository _jobPostingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateJobPostingCommandHandler(
        IJobPostingRepository jobPostingRepository,
        IUnitOfWork unitOfWork)
    {
        _jobPostingRepository = jobPostingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<JobPostingDto>> Handle(
        CreateJobPostingCommand request,
        CancellationToken cancellationToken)
    {
        var jobPosting = new JobPosting
        {
            CompanyId = request.CompanyId,
            JobCategoryId = request.JobCategoryId,
            ProvinceId = request.ProvinceId,
            Title = request.Title,
            Description = request.Description,
            Requirements = request.Requirements,
            Benefits = request.Benefits,
            InternshipDurationMonths = request.InternshipDurationMonths,
            SalaryFrom = request.SalaryFrom,
            SalaryTo = request.SalaryTo,
            Deadline = request.Deadline,
            WorkType = request.WorkType,
            Status = JobPostingStatus.Published
        };

        await _jobPostingRepository.AddAsync(jobPosting);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<JobPostingDto>.Success(
            new JobPostingDto
            {
                Id = jobPosting.Id,
                CompanyId = jobPosting.CompanyId,
                JobCategoryId = jobPosting.JobCategoryId,
                ProvinceId = jobPosting.ProvinceId,
                Title = jobPosting.Title,
                Description = jobPosting.Description,
                Requirements = jobPosting.Requirements,
                Benefits = jobPosting.Benefits,
                InternshipDurationMonths = jobPosting.InternshipDurationMonths,
                SalaryFrom = jobPosting.SalaryFrom,
                SalaryTo = jobPosting.SalaryTo,
                Deadline = jobPosting.Deadline,
                WorkType = jobPosting.WorkType,
                Status = jobPosting.Status
            });
    }
}
