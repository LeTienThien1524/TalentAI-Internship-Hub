using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Dashboard.DTOs;

namespace TalentAI.Application.Features.Dashboard.Queries.GetDashboardSummary;

public record GetDashboardSummaryQuery
    : IRequest<Result<DashboardSummaryDto>>;
