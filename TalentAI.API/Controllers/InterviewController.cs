using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentAI.Application.Features.Interviews.Commands;
using TalentAI.Application.Features.Interviews.Commands.CreateInterviews;
using TalentAI.Application.Features.Interviews.Queries.GetApplicationInterviews;
using TalentAI.Application.Features.Interviews.Queries.GetMyInterviews;

namespace TalentAI.API.Controllers;

[ApiController]
[Route("api/interviews")]
[Authorize]
public class InterviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public InterviewController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateInterviewCommand command)
    {
        var result =
            await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("my")]
    public async Task<IActionResult> GetMy()
    {
        var result =
            await _mediator.Send(
                new GetMyInterviewsQuery());

        return Ok(result);
    }

    [HttpGet("application/{id}")]
    public async Task<IActionResult>
        GetByApplication(Guid id)
    {
        var result =
            await _mediator.Send(
                new GetApplicationInterviewsQuery(id));

        return Ok(result);
    }
}
