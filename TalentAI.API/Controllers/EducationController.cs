using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MediatR;

using TalentAI.Application.Features.Educations.Commands.CreateEducation;
using TalentAI.Application.Features.Educations.Queries.GetMyEducations;
using TalentAI.Application.Features.Educations.Commands.UpdateEducation;
using TalentAI.Application.Features.Educations.Commands.DeleteEducation;

namespace TalentAI.API.Controllers;

[ApiController]
[Route("api/educations")]
public class EducationController
    : ControllerBase
{
    private readonly IMediator _mediator;

    public EducationController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("my")]
    public async Task<IActionResult>
        GetMy(Guid candidateId)
    {
        var result =
            await _mediator.Send(
                new GetMyEducationsQuery(
                    candidateId));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult>
        Create(
            CreateEducationCommand command)
    {
        var result =
            await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult>
    Update(
        Guid id,
        UpdateEducationCommand command)
    {
        command = command with { Id = id };

        var result =
            await _mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult>
    Delete(Guid id)
    {
        var result =
            await _mediator.Send(
                new DeleteEducationCommand(id));

        return Ok(result);
    }
}
