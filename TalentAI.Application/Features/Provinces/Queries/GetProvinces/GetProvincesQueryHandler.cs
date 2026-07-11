using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Provinces.DTOs;

using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Provinces.Queries.GetProvinces;

public class GetProvincesQueryHandler
    : IRequestHandler<
        GetProvincesQuery,
        Result<List<ProvinceDto>>>
{
    private readonly IProvinceRepository
        _provinceRepository;

    public GetProvincesQueryHandler(
        IProvinceRepository provinceRepository)
    {
        _provinceRepository = provinceRepository;
    }

    public async Task<Result<List<ProvinceDto>>>
        Handle(
            GetProvincesQuery request,
            CancellationToken cancellationToken)
    {
        var provinces =
            await _provinceRepository.GetAllAsync();

        var result = provinces
            .Select(x => new ProvinceDto
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToList();

        return Result<List<ProvinceDto>>
            .Success(result);
    }
}