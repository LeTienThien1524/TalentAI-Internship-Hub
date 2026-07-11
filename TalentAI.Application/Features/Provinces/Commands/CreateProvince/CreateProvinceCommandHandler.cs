using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using TalentAI.Application.Common.Models;
using TalentAI.Domain.Entities.Metadata;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Provinces.Commands.CreateProvince;

public class CreateProvinceCommandHandler
    : IRequestHandler<CreateProvinceCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProvinceCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(
        CreateProvinceCommand request,
        CancellationToken cancellationToken)
    {
        var province = new Province
        {
            Name = request.Name
        };

        await _unitOfWork.Provinces.AddAsync(province);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(
            province.Id,
            "Province created successfully.");
    }
}
