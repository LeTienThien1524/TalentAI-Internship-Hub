using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Interviews.DTOs;

using TalentAI.Domain.Entities.Applications;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Interviews.Commands.CreateInterviews;

public class CreateInterviewCommandHandler
    : IRequestHandler<
        CreateInterviewCommand,
        Result<InterviewDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInterviewCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InterviewDto>>
        Handle(
            CreateInterviewCommand request,
            CancellationToken cancellationToken)
    {
        var interview = new Interview
        {
            JobApplicationId =
                request.JobApplicationId,

            ScheduledAt =
                request.ScheduledAt,

            LocationOrLink =
                request.LocationOrLink,

            InterviewerName =
                request.InterviewerName,

            Notes =
                request.Notes
        };

        await _unitOfWork.Interviews
            .AddAsync(interview);

        await _unitOfWork
            .SaveChangesAsync(cancellationToken);

        return Result<InterviewDto>.Success(
            new InterviewDto
            {
                Id = interview.Id,
                JobApplicationId =
                    interview.JobApplicationId,

                ScheduledAt =
                    interview.ScheduledAt,

                LocationOrLink =
                    interview.LocationOrLink,

                InterviewerName =
                    interview.InterviewerName,

                Notes =
                    interview.Notes
            });
    }
}
