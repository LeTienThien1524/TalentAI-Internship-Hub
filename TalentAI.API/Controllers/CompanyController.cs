using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MediatR;
using Microsoft.AspNetCore.Authorization;

using TalentAI.Application.Features.Companies.Commands.UpsertCompanyProfile;
using TalentAI.Application.Features.Companies.Queries.GetCompanyProfile;

namespace TalentAI.API.Controllers;

[Authorize]
[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("profile")]
    public async Task<IActionResult> UpsertProfile(
        UpsertCompanyProfileCommand command)
    {
        var result =
            await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var result =
            await _mediator.Send(
                new GetCompanyProfileQuery());

        return Ok(result);
    }
}
