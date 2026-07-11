using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using TalentAI.Application.Common.Models;
using TalentAI.Domain.Entities.Metadata;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Skills.Commands.CreateSkill;

public class CreateSkillCommandHandler
    : IRequestHandler<CreateSkillCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSkillCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
        CreateSkillCommand request,
        CancellationToken cancellationToken)
    {
        var skill = new Skill
        {
            Name = request.Name
        };

        await _unitOfWork.Skills.AddAsync(skill);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(
            skill.Id,
            "Skill created successfully.");
    }
}
