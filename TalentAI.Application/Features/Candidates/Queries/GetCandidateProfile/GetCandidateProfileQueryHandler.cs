using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Candidates.DTOs;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Candidates.Queries;

public class GetCandidateProfileQueryHandler
    : IRequestHandler<GetCandidateProfileQuery, Result<CandidateDto>>
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly ICurrentUserService _currentUser;

    public GetCandidateProfileQueryHandler(
        ICandidateRepository candidateRepository,
        ICurrentUserService currentUser)
    {
        _candidateRepository = candidateRepository;
        _currentUser = currentUser;
    }

    public async Task<Result<CandidateDto>> Handle(
        GetCandidateProfileQuery request,
        CancellationToken cancellationToken)
    {
        var userId = _currentUser.UserId;

        var candidate = await _candidateRepository
            .GetByUserIdAsync(userId);

        if (candidate == null)
        {
            return Result<CandidateDto>.Failure("Candidate profile not found");
        }

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