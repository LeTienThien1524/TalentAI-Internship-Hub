using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ParsedResumeDto
{
    public Guid ResumeId { get; set; }

    public string? Summary { get; set; }

    public string? ParsedSkills { get; set; }

    public string? ParsedEducation { get; set; }

    public string? ParsedExperience { get; set; }
}
