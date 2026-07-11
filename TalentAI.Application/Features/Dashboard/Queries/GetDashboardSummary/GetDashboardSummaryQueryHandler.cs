using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Dashboard.DTOs;

using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Dashboard.Queries.GetDashboardSummary;

public class GetDashboardSummaryQueryHandler
    : IRequestHandler<
        GetDashboardSummaryQuery,
        Result<DashboardSummaryDto>>
{
    private readonly IDashboardRepository
        _dashboardRepository;

    public GetDashboardSummaryQueryHandler(
        IDashboardRepository dashboardRepository)
    {
        _dashboardRepository = dashboardRepository;
    }

    public async Task<Result<DashboardSummaryDto>>
        Handle(
            GetDashboardSummaryQuery request,
            CancellationToken cancellationToken)
    {
        var dto =
            new DashboardSummaryDto
            {
                TotalCandidates =
                    await _dashboardRepository
                        .GetTotalCandidatesAsync(),

                TotalCompanies =
                    await _dashboardRepository
                        .GetTotalCompaniesAsync(),

                TotalJobs =
                    await _dashboardRepository
                        .GetTotalJobsAsync(),

                TotalApplications =
                    await _dashboardRepository
                        .GetTotalApplicationsAsync(),

                TotalInterviews =
                    await _dashboardRepository
                        .GetTotalInterviewsAsync()
            };

        return Result<DashboardSummaryDto>
            .Success(dto);
    }
}
