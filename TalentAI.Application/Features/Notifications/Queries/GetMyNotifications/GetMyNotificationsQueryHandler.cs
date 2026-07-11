using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Notifications.DTOs;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Notifications.Queries.GetMyNotifications;

public class GetMyNotificationsQueryHandler
    : IRequestHandler<
        GetMyNotificationsQuery,
        Result<List<NotificationDto>>>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly ICurrentUserService _currentUser;

    public GetMyNotificationsQueryHandler(
        INotificationRepository notificationRepository,
        ICurrentUserService currentUser)
    {
        _notificationRepository = notificationRepository;
        _currentUser = currentUser;
    }

    public async Task<Result<List<NotificationDto>>> Handle(
        GetMyNotificationsQuery request,
        CancellationToken cancellationToken)
    {
        var notifications =
            await _notificationRepository
                .GetByUserIdAsync(_currentUser.UserId);

        var result = notifications
            .Select(x => new NotificationDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                IsRead = x.IsRead,
                CreatedAt = x.CreatedAt
            })
            .ToList();

        return Result<List<NotificationDto>>
            .Success(result);
    }
}
