using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using TalentAI.Application.Common.Models;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.JobCategories.Commands.UpdateJobCategory;

public class UpdateJobCategoryCommandHandler
    : IRequestHandler<UpdateJobCategoryCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateJobCategoryCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        UpdateJobCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var jobCategory = await _unitOfWork.JobCategories
            .GetByIdAsync(request.Id);

        if (jobCategory is null)
        {
            return Result.NotFound(
                "Job category not found.");
        }

        jobCategory.Name = request.Name;

        _unitOfWork.JobCategories.Update(jobCategory);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(
            "Job category updated successfully.");
    }
}
