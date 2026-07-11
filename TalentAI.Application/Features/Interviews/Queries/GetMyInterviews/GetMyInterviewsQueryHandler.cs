using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Interviews.DTOs;
using TalentAI.Application.Interfaces;

using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Interviews.Queries.GetMyInterviews;

public class GetMyInterviewsQueryHandler
    : IRequestHandler<
        GetMyInterviewsQuery,
        Result<List<InterviewDto>>>
{
    private readonly ICurrentUserService _currentUser;
    private readonly IUnitOfWork _unitOfWork;

    public GetMyInterviewsQueryHandler(
        ICurrentUserService currentUser,
        IUnitOfWork unitOfWork)
    {
        _currentUser = currentUser;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<List<InterviewDto>>> Handle(
        GetMyInterviewsQuery request,
        CancellationToken cancellationToken)
    {
        var candidate =
            await _unitOfWork.Candidates
                .GetByUserIdAsync(_currentUser.UserId);

        if (candidate is null)
        {
            return Result<List<InterviewDto>>
                .Failure("Candidate not found");
        }

        var interviews =
            await _unitOfWork.Interviews
                .GetByCandidateIdAsync(candidate.Id);

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
