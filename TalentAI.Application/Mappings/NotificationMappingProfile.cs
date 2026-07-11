using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Application.Features.Notifications.DTOs;
using TalentAI.Domain.Entities.Applications;
using TalentAI.Domain.Entities.System;

namespace TalentAI.Application.Mappings;

public class NotificationMappingProfile : Profile
{
    public NotificationMappingProfile()
    {
        CreateMap<Notification, NotificationDto>();
    }
}
