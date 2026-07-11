using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Companies.DTOs;

namespace TalentAI.Application.Features.Companies.Commands.UpsertCompanyProfile;

public class UpsertCompanyProfileCommand
    : IRequest<Result<CompanyDto>>
{
    public int ProvinceId { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public string? TaxCode { get; set; }

    public string? Website { get; set; }

    public string? LogoUrl { get; set; }

    public string? Description { get; set; }
}
