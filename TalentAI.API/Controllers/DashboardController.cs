using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MediatR;

using TalentAI.Application.Features.Dashboard.Queries.GetDashboardSummary;

namespace TalentAI.API.Controllers;

[ApiController]
[Route("api/dashboards")]
public class DashboardController
    : ControllerBase
{
    private readonly IMediator _mediator;

    public DashboardController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("summary")]
    public async Task<IActionResult>
        GetSummary()
    {
        var result =
            await _mediator.Send(
                new GetDashboardSummaryQuery());

        return Ok(result);
    }
}
