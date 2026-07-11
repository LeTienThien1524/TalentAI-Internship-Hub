using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using TalentAI.Application.Common.Models;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Skills.Commands.UpdateSkill;

public class UpdateSkillCommandHandler
    : IRequestHandler<UpdateSkillCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSkillCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        UpdateSkillCommand request,
        CancellationToken cancellationToken)
    {
        var skill = await _unitOfWork.Skills
            .GetByIdAsync(request.Id);

        if (skill is null)
        {
            return Result.NotFound(
                "Skill not found.");
        }

        skill.Name = request.Name;

        _unitOfWork.Skills.Update(skill);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(
            "Skill updated successfully.");
    }
}
