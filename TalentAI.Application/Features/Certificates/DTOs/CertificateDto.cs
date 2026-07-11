using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAI.Application.Features.Certificates.DTOs;

public class CertificateDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }
        = string.Empty;

    public string Issuer { get; set; }
        = string.Empty;

    public DateTime? IssueDate { get; set; }
}
