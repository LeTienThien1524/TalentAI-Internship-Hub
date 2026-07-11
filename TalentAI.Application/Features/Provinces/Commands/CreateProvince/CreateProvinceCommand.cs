using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;

namespace TalentAI.Application.Features.Provinces.Commands.CreateProvince;

public class CreateProvinceCommand : IRequest<Result<int>>
{
    public string Name { get; set; } = string.Empty;
}
