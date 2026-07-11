using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MediatR;
using Microsoft.AspNetCore.Authorization;

using TalentAI.Application.Features.AI.Commands.ParseResume;
using TalentAI.Application.Features.AI.Commands.CalculateMatchScore;
using TalentAI.Application.Features.AI.Queries.GetRecommendedJobs;

namespace TalentAI.API.Controllers;

[Authorize]
[ApiController]
[Route("api/ai")]
public class AIController
    : ControllerBase
{
    private readonly IMediator _mediator;

    public AIController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("parse-resume/{resumeId}")]
    public async Task<IActionResult> ParseResume(
        Guid resumeId)
    {
        var result =
            await _mediator.Send(
                new ParseResumeCommand
                {
                    ResumeId = resumeId
                });

        return Ok(result);
    }

    [HttpPost("match-score/{applicationId}")]
    public async Task<IActionResult> MatchScore(
        Guid applicationId)
    {
        var result =
            await _mediator.Send(
                new CalculateMatchScoreCommand
                {
                    JobApplicationId =
                        applicationId
                });

        return Ok(result);
    }

    [HttpGet("recommended-jobs")]
    public async Task<IActionResult>
        GetRecommendedJobs()
    {
        var result =
            await _mediator.Send(
                new GetRecommendedJobsQuery());

        return Ok(result);
    }
}
