using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MediatR;
using Microsoft.AspNetCore.Authorization;

using TalentAI.Application.Features.Notifications.Commands.MarkNotificationAsRead;
using TalentAI.Application.Features.Notifications.Queries.GetMyNotifications;

namespace TalentAI.API.Controllers;

[Authorize]
[ApiController]
[Route("api/notifications")]
public class NotificationController
    : ControllerBase
{
    private readonly IMediator _mediator;

    public NotificationController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetMyNotifications()
    {
        var result =
            await _mediator.Send(
                new GetMyNotificationsQuery());

        return Ok(result);
    }

    [HttpPut("read/{id}")]
    public async Task<IActionResult> MarkAsRead(
        Guid id)
    {
        var result =
            await _mediator.Send(
                new MarkNotificationAsReadCommand
                {
                    NotificationId = id
                });

        return Ok(result);
    }
}
