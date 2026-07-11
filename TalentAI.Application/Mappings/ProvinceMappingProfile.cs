using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using TalentAI.Application.Features.Provinces.DTOs;

using TalentAI.Domain.Entities.Metadata;

namespace TalentAI.Application.Mappings;

public class ProvinceMappingProfile : Profile
{
    public ProvinceMappingProfile()
    {
        CreateMap<Province, ProvinceDto>();
    }
}
