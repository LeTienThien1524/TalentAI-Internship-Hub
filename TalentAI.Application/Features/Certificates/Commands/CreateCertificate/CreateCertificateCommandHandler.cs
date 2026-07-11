using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Certificates.DTOs;

using TalentAI.Domain.Entities.Profiles;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Certificates.Commands.CreateCertificate;

public class CreateCertificateCommandHandler
    : IRequestHandler<
        CreateCertificateCommand,
        Result<CertificateDto>>
{
    private readonly ICertificateRepository
        _certificateRepository;

    public CreateCertificateCommandHandler(
        ICertificateRepository certificateRepository)
    {
        _certificateRepository =
            certificateRepository;
    }

    public async Task<Result<CertificateDto>>
        Handle(
            CreateCertificateCommand request,
            CancellationToken cancellationToken)
    {
        var certificate =
            new Certificate
            {
                CandidateId = request.CandidateId,
                Name = request.Name,
                Issuer = request.Issuer,
                IssueDate = request.IssueDate
            };

        await _certificateRepository
            .AddAsync(certificate);

        await _certificateRepository
            .SaveChangesAsync();

        return Result<CertificateDto>
            .Success(
                new CertificateDto
                {
                    Id = certificate.Id,
                    Name = certificate.Name,
                    Issuer = certificate.Issuer,
                    IssueDate = certificate.IssueDate
                });
    }
}
