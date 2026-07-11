using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using TalentAI.Application.Common.Models;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Provinces.Commands.UpdateProvince;

public class UpdateProvinceCommandHandler
    : IRequestHandler<UpdateProvinceCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProvinceCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        UpdateProvinceCommand request,
        CancellationToken cancellationToken)
    {
        var province = await _unitOfWork.Provinces
            .GetByIdAsync(request.Id);

        if (province is null)
        {
            return Result.NotFound(
                "Province not found.");
        }

        province.Name = request.Name;

        _unitOfWork.Provinces.Update(province);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(
            "Province updated successfully.");
    }
}
