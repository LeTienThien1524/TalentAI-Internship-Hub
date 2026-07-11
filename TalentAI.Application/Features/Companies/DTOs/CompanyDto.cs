using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAI.Application.Features.Companies.DTOs;

public class CompanyDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public int ProvinceId { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public string? TaxCode { get; set; }

    public string? Website { get; set; }

    public string? LogoUrl { get; set; }

    public string? Description { get; set; }

    public bool IsVerified { get; set; }
}
