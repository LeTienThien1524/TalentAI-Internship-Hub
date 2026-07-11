using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Notifications.DTOs;

namespace TalentAI.Application.Features.Notifications.Queries.GetMyNotifications;

public class GetMyNotificationsQuery
    : IRequest<Result<List<NotificationDto>>>
{
}
