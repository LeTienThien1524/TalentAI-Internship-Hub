using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using TalentAI.Application.Common.Models;
using TalentAI.Domain.Entities.Metadata;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.JobCategories.Commands.CreateJobCategory;

public class CreateJobCategoryCommandHandler
    : IRequestHandler<CreateJobCategoryCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateJobCategoryCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
        CreateJobCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var jobCategory = new JobCategory
        {
            Name = request.Name
        };

        await _unitOfWork.JobCategories.AddAsync(jobCategory);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(
            jobCategory.Id,
            "Job category created successfully.");
    }
}
