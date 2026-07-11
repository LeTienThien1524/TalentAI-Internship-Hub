using MediatR;
using Microsoft.AspNetCore.Mvc;

using TalentAI.Application.Features.JobCategories.Commands.CreateJobCategory;
using TalentAI.Application.Features.JobCategories.Commands.DeleteJobCategory;
using TalentAI.Application.Features.JobCategories.Commands.UpdateJobCategory;
using TalentAI.Application.Features.JobCategories.Queries.GetJobCategories;
using TalentAI.Application.Features.JobCategories.Queries.GetJobCategoryById;

namespace TalentAI.API.Controllers;

[ApiController]
[Route("api/job-categories")]
public class JobCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobCategoryController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(
            new GetJobCategoriesQuery());

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(
        int id)
    {
        var result = await _mediator.Send(
            new GetJobCategoryByIdQuery
            {
                Id = id
            });

        if (result.IsFailure)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateJobCategoryCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateJobCategoryCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(command);

        if (result.IsFailure)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(
        int id)
    {
        var result = await _mediator.Send(
            new DeleteJobCategoryCommand
            {
                Id = id
            });

        if (result.IsFailure)
        {
            return NotFound(result);
        }

        return Ok(result);
    }
}