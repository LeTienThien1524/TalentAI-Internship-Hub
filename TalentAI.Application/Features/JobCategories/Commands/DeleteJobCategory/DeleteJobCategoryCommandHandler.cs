using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using TalentAI.Application.Common.Models;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.JobCategories.Commands.DeleteJobCategory;

public class DeleteJobCategoryCommandHandler
    : IRequestHandler<DeleteJobCategoryCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteJobCategoryCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        DeleteJobCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var jobCategory = await _unitOfWork.JobCategories
            .GetByIdAsync(request.Id);

        if (jobCategory is null)
        {
            return Result.NotFound(
                "Job category not found.");
        }

        _unitOfWork.JobCategories.Delete(jobCategory);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(
            "Job category deleted successfully.");
    }
}
