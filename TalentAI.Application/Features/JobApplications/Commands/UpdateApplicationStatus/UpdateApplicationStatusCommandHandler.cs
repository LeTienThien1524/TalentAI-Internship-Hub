using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobApplications.DTOs;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Entities.Applications;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.JobApplications.Commands.UpdateApplicationStatus;

public class UpdateApplicationStatusCommandHandler
    : IRequestHandler<
        UpdateApplicationStatusCommand,
        Result<ApplicationHistoryDto>>
{
    private readonly IJobApplicationRepository _jobApplicationRepository;
    private readonly IApplicationHistoryRepository _historyRepository;
    private readonly ICurrentUserService _currentUser;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateApplicationStatusCommandHandler(
        IJobApplicationRepository jobApplicationRepository,
        IApplicationHistoryRepository historyRepository,
        ICurrentUserService currentUser,
        IUnitOfWork unitOfWork)
    {
        _jobApplicationRepository = jobApplicationRepository;
        _historyRepository = historyRepository;
        _currentUser = currentUser;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ApplicationHistoryDto>> Handle(
        UpdateApplicationStatusCommand request,
        CancellationToken cancellationToken)
    {
        var application =
            await _jobApplicationRepository
                .GetByIdAsync(request.JobApplicationId);

        if (application == null)
        {
            return Result<ApplicationHistoryDto>
                .Failure("Application not found.");
        }

        var history = new ApplicationHistory
        {
            JobApplicationId = application.Id,
            ChangedByUserId = _currentUser.UserId,
            Status = request.Status,
            Note = request.Note,
            ChangedAt = DateTime.UtcNow
        };

        await _historyRepository.AddAsync(history);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result<ApplicationHistoryDto>.Success(
            new ApplicationHistoryDto
            {
                Id = history.Id,
                JobApplicationId = history.JobApplicationId,
                ChangedByUserId = history.ChangedByUserId,
                Status = history.Status,
                Note = history.Note,
                ChangedAt = history.ChangedAt
            });
    }
}
