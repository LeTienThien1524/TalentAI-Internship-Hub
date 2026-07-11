using MediatR;
using Microsoft.AspNetCore.Mvc;

using TalentAI.Application.Features.Provinces.Commands.CreateProvince;
using TalentAI.Application.Features.Provinces.Commands.DeleteProvince;
using TalentAI.Application.Features.Provinces.Commands.UpdateProvince;
using TalentAI.Application.Features.Provinces.Queries.GetProvinceById;
using TalentAI.Application.Features.Provinces.Queries.GetProvinces;

namespace TalentAI.API.Controllers;

[ApiController]
[Route("api/provinces")]
public class ProvinceController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProvinceController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(
            new GetProvincesQuery());

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(
        int id)
    {
        var result = await _mediator.Send(
            new GetProvinceByIdQuery
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
        CreateProvinceCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateProvinceCommand command)
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
            new DeleteProvinceCommand
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