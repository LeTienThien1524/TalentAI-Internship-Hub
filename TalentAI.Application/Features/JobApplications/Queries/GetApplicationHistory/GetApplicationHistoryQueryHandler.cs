using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobApplications.DTOs;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.JobApplications.Queries.GetApplicationHistory;

public class GetApplicationHistoryQueryHandler
    : IRequestHandler<
        GetApplicationHistoryQuery,
        Result<List<ApplicationHistoryDto>>>
{
    private readonly IApplicationHistoryRepository
        _historyRepository;

    public GetApplicationHistoryQueryHandler(
        IApplicationHistoryRepository historyRepository)
    {
        _historyRepository = historyRepository;
    }

    public async Task<Result<List<ApplicationHistoryDto>>> Handle(
        GetApplicationHistoryQuery request,
        CancellationToken cancellationToken)
    {
        var histories =
            await _historyRepository
                .GetByApplicationIdAsync(
                    request.JobApplicationId);

        return Result<List<ApplicationHistoryDto>>
            .Success(
                histories.Select(x =>
                    new ApplicationHistoryDto
                    {
                        Id = x.Id,
                        JobApplicationId = x.JobApplicationId,
                        ChangedByUserId = x.ChangedByUserId,
                        Status = x.Status,
                        Note = x.Note,
                        ChangedAt = x.ChangedAt
                    }).ToList());
    }
}
