using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Certificates.Commands.UpdateCertificate;

public class UpdateCertificateCommandHandler
    : IRequestHandler<
        UpdateCertificateCommand,
        Result>
{
    private readonly ICertificateRepository
        _certificateRepository;

    public UpdateCertificateCommandHandler(
        ICertificateRepository certificateRepository)
    {
        _certificateRepository =
            certificateRepository;
    }

    public async Task<Result>
        Handle(
            UpdateCertificateCommand request,
            CancellationToken cancellationToken)
    {
        var certificate =
            await _certificateRepository
                .GetByIdAsync(request.Id);

        if (certificate is null)
        {
            return Result.Failure(
                "Certificate not found");
        }

        certificate.Name = request.Name;
        certificate.Issuer = request.Issuer;
        certificate.IssueDate = request.IssueDate;

        _certificateRepository.Update(certificate);

        await _certificateRepository
            .SaveChangesAsync();

        return Result.Success();
    }
}
