using MediatR;
using Microsoft.AspNetCore.Mvc;

using TalentAI.Application.Features.Skills.Commands.CreateSkill;
using TalentAI.Application.Features.Skills.Commands.DeleteSkill;
using TalentAI.Application.Features.Skills.Commands.UpdateSkill;
using TalentAI.Application.Features.Skills.Queries.GetSkillById;
using TalentAI.Application.Features.Skills.Queries.GetSkills;

namespace TalentAI.API.Controllers;

[ApiController]
[Route("api/skills")]
public class SkillController : ControllerBase
{
    private readonly IMediator _mediator;

    public SkillController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(
            new GetSkillsQuery());

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(
        int id)
    {
        var result = await _mediator.Send(
            new GetSkillByIdQuery
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
        CreateSkillCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateSkillCommand command)
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
            new DeleteSkillCommand
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