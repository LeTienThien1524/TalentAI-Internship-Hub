using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.AI.Queries.GetRecommendedJobs;

public class GetRecommendedJobsQueryHandler
    : IRequestHandler<
        GetRecommendedJobsQuery,
        Result<List<Guid>>>
{
    private readonly IJobPostingRepository _jobRepository;

    public GetRecommendedJobsQueryHandler(
        IJobPostingRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<Result<List<Guid>>> Handle(
        GetRecommendedJobsQuery request,
        CancellationToken cancellationToken)
    {
        var jobs =
            await _jobRepository.GetActiveJobsAsync();

        var result =
            jobs.Take(10)
                .Select(x => x.Id)
                .ToList();

        return Result<List<Guid>>
            .Success(result);
    }
}
