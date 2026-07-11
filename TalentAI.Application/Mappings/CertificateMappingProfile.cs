using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using TalentAI.Application.Features.Certificates.DTOs;

using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Application.Mappings;

public class CertificateMappingProfile : Profile
{
    public CertificateMappingProfile()
    {
        CreateMap<Certificate, CertificateDto>();
    }
}
