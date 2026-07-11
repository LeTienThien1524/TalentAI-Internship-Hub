using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Domain.Entities.Applications;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.AI.Commands.CalculateMatchScore;

public class CalculateMatchScoreCommandHandler
    : IRequestHandler<
        CalculateMatchScoreCommand,
        Result<MatchScoreDto>>
{
    private readonly IAIMatchScoreRepository _scoreRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CalculateMatchScoreCommandHandler(
        IAIMatchScoreRepository scoreRepository,
        IUnitOfWork unitOfWork)
    {
        _scoreRepository = scoreRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<MatchScoreDto>> Handle(
        CalculateMatchScoreCommand request,
        CancellationToken cancellationToken)
    {
        var score = new AIMatchScore
        {
            JobApplicationId =
                request.JobApplicationId,

            MatchPercentage = 80,

            CoreStrengths =
                "C#, ASP.NET Core",

            SkillGaps =
                "React",

            AIExplanation =
                "Candidate matches most required skills.",

            EvaluatedAt =
                DateTime.UtcNow
        };

        await _scoreRepository.AddAsync(score);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result<MatchScoreDto>.Success(
            new MatchScoreDto
            {
                JobApplicationId =
                    score.JobApplicationId,

                MatchPercentage =
                    score.MatchPercentage,

                CoreStrengths =
                    score.CoreStrengths,

                SkillGaps =
                    score.SkillGaps,

                AIExplanation =
                    score.AIExplanation
            });
    }
}
