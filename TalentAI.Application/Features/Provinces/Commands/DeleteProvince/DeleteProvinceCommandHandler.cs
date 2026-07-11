using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using TalentAI.Application.Common.Models;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Provinces.Commands.DeleteProvince;

public class DeleteProvinceCommandHandler
    : IRequestHandler<DeleteProvinceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProvinceCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        DeleteProvinceCommand request,
        CancellationToken cancellationToken)
    {
        var province = await _unitOfWork.Provinces
            .GetByIdAsync(request.Id);

        if (province is null)
        {
            return Result.NotFound(
                "Province not found.");
        }

        _unitOfWork.Provinces.Delete(province);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(
            "Province deleted successfully.");
    }
}
