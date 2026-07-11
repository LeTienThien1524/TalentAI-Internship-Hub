using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MediatR;
using Microsoft.AspNetCore.Authorization;

using TalentAI.Application.Features.Resumes.Commands.UploadResume;
using TalentAI.Application.Features.Resumes.Queries.GetMyResumes;
using TalentAI.Application.Features.Resumes.Queries.GetResumeById;

namespace TalentAI.API.Controllers;

[Authorize]
[ApiController]
[Route("api/resumes")]
public class ResumeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResumeController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(
        UploadResumeCommand command)
    {
        var result =
            await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetMyResumes()
    {
        var result =
            await _mediator.Send(
                new GetMyResumesQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id)
    {
        var result =
            await _mediator.Send(
                new GetResumeByIdQuery
                {
                    Id = id
                });

        return Ok(result);
    }
}
