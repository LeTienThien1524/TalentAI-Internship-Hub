using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAI.Application.Features.Educations.DTOs;

public class EducationDto
{
    public Guid Id { get; set; }

    public string University { get; set; } = string.Empty;

    public string Major { get; set; } = string.Empty;

    public string Degree { get; set; } = string.Empty;

    public decimal? GPA { get; set; }

    public int StartYear { get; set; }

    public int? EndYear { get; set; }
}
