using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Provinces.DTOs;

namespace TalentAI.Application.Features.Provinces.Queries.GetProvinceById;

public class GetProvinceByIdQuery
    : IRequest<Result<ProvinceDto>>
{
    public int Id { get; set; }
}
