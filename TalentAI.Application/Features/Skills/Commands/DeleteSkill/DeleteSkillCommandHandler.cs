using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using TalentAI.Application.Common.Models;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Skills.Commands.DeleteSkill;

public class DeleteSkillCommandHandler
    : IRequestHandler<DeleteSkillCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSkillCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        DeleteSkillCommand request,
        CancellationToken cancellationToken)
    {
        var skill = await _unitOfWork.Skills
            .GetByIdAsync(request.Id);

        if (skill is null)
        {
            return Result.NotFound(
                "Skill not found.");
        }

        _unitOfWork.Skills.Delete(skill);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(
            "Skill deleted successfully.");
    }
}
