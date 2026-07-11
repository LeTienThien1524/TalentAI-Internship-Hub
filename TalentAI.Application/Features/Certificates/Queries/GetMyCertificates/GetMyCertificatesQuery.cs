using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Certificates.DTOs;

namespace TalentAI.Application.Features.Certificates.Queries.GetMyCertificates;

public record GetMyCertificatesQuery(
    Guid CandidateId)
    : IRequest<Result<List<CertificateDto>>>;
