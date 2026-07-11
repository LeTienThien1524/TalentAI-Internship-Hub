using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MediatR;
using Microsoft.AspNetCore.Authorization;

using TalentAI.Application.Features.JobApplications.Commands.CreateJobApplication;
using TalentAI.Application.Features.JobApplications.Queries.GetMyJobApplications;
using TalentAI.Application.Features.JobApplications.Queries.GetJobApplicants;
using TalentAI.Application.Features.JobApplications.Commands.UpdateApplicationStatus;
using TalentAI.Application.Features.JobApplications.Queries.GetApplicationHistory;

namespace TalentAI.API.Controllers;

[Authorize]
[ApiController]
[Route("api/job-applications")]
public class JobApplicationController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobApplicationController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Apply(
        CreateJobApplicationCommand command)
    {
        var result =
            await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("job/{jobPostingId}")]
    public async Task<IActionResult> GetApplicants(
    Guid jobPostingId)
    {
        var result =
            await _mediator.Send(
                new GetJobApplicantsQuery
                {
                    JobPostingId = jobPostingId
                });

        return Ok(result);
    }

    [HttpGet("my")]
    public async Task<IActionResult> GetMyApplications()
    {
        var result =
            await _mediator.Send(
                new GetMyJobApplicationsQuery());

        return Ok(result);
    }

    [HttpPut("status")]
    public async Task<IActionResult> UpdateStatus(
    UpdateApplicationStatusCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("history/{applicationId}")]
    public async Task<IActionResult> GetHistory(
    Guid applicationId)
    {
        var result = await _mediator.Send(
            new GetApplicationHistoryQuery
            {
                JobApplicationId = applicationId
            });

        return Ok(result);
    }
}
