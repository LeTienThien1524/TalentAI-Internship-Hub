using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Certificates.DTOs;

using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Certificates.Queries.GetMyCertificates;

public class GetMyCertificatesQueryHandler
    : IRequestHandler<
        GetMyCertificatesQuery,
        Result<List<CertificateDto>>>
{
    private readonly ICertificateRepository
        _certificateRepository;

    public GetMyCertificatesQueryHandler(
        ICertificateRepository certificateRepository)
    {
        _certificateRepository =
            certificateRepository;
    }

    public async Task<Result<List<CertificateDto>>>
        Handle(
            GetMyCertificatesQuery request,
            CancellationToken cancellationToken)
    {
        var certificates =
            await _certificateRepository
                .GetByCandidateIdAsync(
                    request.CandidateId);

        var result = certificates
            .Select(x => new CertificateDto
            {
                Id = x.Id,
                Name = x.Name,
                Issuer = x.Issuer,
                IssueDate = x.IssueDate
            })
            .ToList();

        return Result<List<CertificateDto>>
            .Success(result);
    }
}
