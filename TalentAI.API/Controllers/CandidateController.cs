using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalentAI.Application.Features.Candidates.Commands;
using TalentAI.Application.Features.Candidates.Queries;

namespace TalentAI.API.Controllers;

[ApiController]
[Route("api/candidates")]
//[Authorize(Roles = "Candidate")]
public class CandidateController : ControllerBase
{
    private readonly IMediator _mediator;

    public CandidateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("profile")]
    public async Task<IActionResult> UpsertProfile(
        UpsertCandidateProfileCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var result = await _mediator.Send(new GetCandidateProfileQuery());
        return Ok(result);
    }
}
