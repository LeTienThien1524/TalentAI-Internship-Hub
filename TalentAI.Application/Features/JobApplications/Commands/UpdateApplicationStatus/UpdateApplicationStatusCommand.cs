using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobApplications.DTOs;
using TalentAI.Domain.Enums;

namespace TalentAI.Application.Features.JobApplications.Commands.UpdateApplicationStatus;

public class UpdateApplicationStatusCommand
    : IRequest<Result<ApplicationHistoryDto>>
{
    public Guid JobApplicationId { get; set; }

    public ApplicationStatus Status { get; set; }

    public string? Note { get; set; }
}
