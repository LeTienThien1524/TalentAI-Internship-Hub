using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Interviews.DTOs;

using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Interviews.Queries.GetApplicationInterviews;

public class GetApplicationInterviewsQueryHandler
    : IRequestHandler<
        GetApplicationInterviewsQuery,
        Result<List<InterviewDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetApplicationInterviewsQueryHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<List<InterviewDto>>> Handle(
        GetApplicationInterviewsQuery request,
        CancellationToken cancellationToken)
    {
        var interviews =
            await _unitOfWork.Interviews
                .GetByJobApplicationIdAsync(
                    request.JobApplicationId);

        var result = interviews
            .Select(x => new InterviewDto
            {
                Id = x.Id,
                JobApplicationId = x.JobApplicationId,
                ScheduledAt = x.ScheduledAt,
                LocationOrLink = x.LocationOrLink,
                InterviewerName = x.InterviewerName,
                Notes = x.Notes
            })
            .ToList();

        return Result<List<InterviewDto>>
            .Success(result);
    }
}
