using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAI.Application.Features.Candidates.DTOs;

public class CandidateDto
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public DateOnly? DateOfBirth { get; set; }

    public int ProvinceId { get; set; }

    public string? AvatarUrl { get; set; }
}
