using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MediatR;

using TalentAI.Application.Features.JobPostings.Commands.CreateJobPosting;
using TalentAI.Application.Features.JobPostings.Queries.GetJobPostingById;
using TalentAI.Application.Features.JobPostings.Queries.GetJobPostingList;

namespace TalentAI.API.Controllers;

[ApiController]
[Route("api/job-postings")]
public class JobPostingController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobPostingController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateJobPostingCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id)
    {
        var result = await _mediator.Send(
            new GetJobPostingByIdQuery
            {
                Id = id
            });

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(
            new GetJobPostingListQuery());

        return Ok(result);
    }
}
