using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobCategories.DTOs;

using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.JobCategories.Queries.GetJobCategories;

public class GetJobCategoriesQueryHandler
    : IRequestHandler<
        GetJobCategoriesQuery,
        Result<List<JobCategoryDto>>>
{
    private readonly IJobCategoryRepository
        _jobCategoryRepository;

    public GetJobCategoriesQueryHandler(
        IJobCategoryRepository jobCategoryRepository)
    {
        _jobCategoryRepository =
            jobCategoryRepository;
    }

    public async Task<Result<List<JobCategoryDto>>>
        Handle(
            GetJobCategoriesQuery request,
            CancellationToken cancellationToken)
    {
        var categories =
            await _jobCategoryRepository
                .GetAllAsync();

        var result = categories
            .Select(x => new JobCategoryDto
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToList();

        return Result<List<JobCategoryDto>>
            .Success(result);
    }
}
