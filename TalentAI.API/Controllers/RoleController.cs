using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentAI.Application.Features.Roles.Commands.AssignRole;
using TalentAI.Application.Features.Roles.Commands.CreateRole;
using TalentAI.Application.Features.Roles.Commands.DeleteRole;
using TalentAI.Application.Features.Roles.Commands.UpdateRole;
using TalentAI.Application.Features.Roles.Queries.GetRoles;
using TalentAI.Application.Features.Roles.Queries.GetUserRoles;

namespace TalentAI.API.Controllers;

[ApiController]
[Route("api/roles")]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles()
    {
        var result =
            await _mediator.Send(
                new GetRolesQuery());

        return Ok(result);
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetUserRoles(
        Guid userId)
    {
        var result =
            await _mediator.Send(
                new GetUserRolesQuery(userId));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(
        CreateRoleCommand command)
    {
        var result =
            await _mediator.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost("assign")]
    public async Task<IActionResult> AssignRole(
        AssignRoleCommand command)
    {
        var result =
            await _mediator.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
    Guid id,
    UpdateRoleCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(command);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(
            new DeleteRoleCommand
            {
                Id = id
            });

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
