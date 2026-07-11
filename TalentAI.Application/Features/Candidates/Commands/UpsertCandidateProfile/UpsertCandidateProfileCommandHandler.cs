using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Candidates.DTOs;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Entities.Profiles;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Candidates.Commands;

public class UpsertCandidateProfileCommandHandler
    : IRequestHandler<UpsertCandidateProfileCommand, Result<CandidateDto>>
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUser;

    public UpsertCandidateProfileCommandHandler(
        ICandidateRepository candidateRepository,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUser)
    {
        _candidateRepository = candidateRepository;
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
    }

    public async Task<Result<CandidateDto>> Handle(
        UpsertCandidateProfileCommand request,
        CancellationToken cancellationToken)
    {
        var userId = _currentUser.UserId;

        var candidate = await _candidateRepository.GetByUserIdAsync(userId);

        if (candidate == null)
        {
            candidate = new Candidate
            {
                UserId = userId,
                FullName = request.FullName,
                DateOfBirth = request.DateOfBirth,
                ProvinceId = request.ProvinceId
            };

            _candidateRepository.Add(candidate);
        }
        else
        {
            candidate.FullName = request.FullName;
            candidate.DateOfBirth = request.DateOfBirth;
            candidate.ProvinceId = request.ProvinceId;

            _candidateRepository.Update(candidate);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<CandidateDto>.Success(new CandidateDto
        {
            Id = candidate.Id,
            FullName = candidate.FullName,
            DateOfBirth = candidate.DateOfBirth,
            ProvinceId = candidate.ProvinceId ?? 64,
            AvatarUrl = candidate.AvatarUrl
        });
    }
}
