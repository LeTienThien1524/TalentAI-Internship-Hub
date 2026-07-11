using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Interviews.DTOs;

namespace TalentAI.Application.Features.Interviews.Commands.CreateInterviews;

public record CreateInterviewCommand(
    Guid JobApplicationId,
    DateTime ScheduledAt,
    string LocationOrLink,
    string InterviewerName,
    string? Notes
)
: IRequest<Result<InterviewDto>>;
