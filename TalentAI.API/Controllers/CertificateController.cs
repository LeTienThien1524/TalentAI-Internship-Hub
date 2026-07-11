using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MediatR;

using TalentAI.Application.Features.Certificates.Commands.CreateCertificate;
using TalentAI.Application.Features.Certificates.Commands.DeleteCertificate;
using TalentAI.Application.Features.Certificates.Commands.UpdateCertificate;
using TalentAI.Application.Features.Certificates.Queries.GetMyCertificates;

namespace TalentAI.API.Controllers;

[ApiController]
[Route("api/certificates")]
public class CertificateController
    : ControllerBase
{
    private readonly IMediator _mediator;

    public CertificateController(
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
                new GetMyCertificatesQuery(
                    candidateId));

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult>
        Create(
            CreateCertificateCommand command)
    {
        var result =
            await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult>
        Update(
            Guid id,
            UpdateCertificateCommand command)
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
                new DeleteCertificateCommand(id));

        return Ok(result);
    }
}
