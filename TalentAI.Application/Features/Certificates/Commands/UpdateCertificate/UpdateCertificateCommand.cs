using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;

namespace TalentAI.Application.Features.Certificates.Commands.UpdateCertificate;

public record UpdateCertificateCommand(
    Guid Id,
    string Name,
    string Issuer,
    DateTime? IssueDate)
    : IRequest<Result>;
