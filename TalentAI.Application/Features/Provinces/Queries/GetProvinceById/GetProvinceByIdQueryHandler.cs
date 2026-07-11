using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Provinces.DTOs;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Provinces.Queries.GetProvinceById;

public class GetProvinceByIdQueryHandler
    : IRequestHandler<
        GetProvinceByIdQuery,
        Result<ProvinceDto>>
{
    private readonly IProvinceRepository _provinceRepository;

    private readonly IMapper _mapper;

    public GetProvinceByIdQueryHandler(
        IProvinceRepository provinceRepository,
        IMapper mapper)
    {
        _provinceRepository = provinceRepository;
        _mapper = mapper;
    }

    public async Task<Result<ProvinceDto>> Handle(
        GetProvinceByIdQuery request,
        CancellationToken cancellationToken)
    {
        var province =
            await _provinceRepository.GetByIdAsync(request.Id);

        if (province is null)
        {
            return Result<ProvinceDto>.NotFound(
                "Province not found.");
        }

        var dto =
            _mapper.Map<ProvinceDto>(province);

        return Result<ProvinceDto>.Success(dto);
    }
}
