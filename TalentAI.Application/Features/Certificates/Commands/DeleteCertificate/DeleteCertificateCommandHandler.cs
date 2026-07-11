using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Certificates.Commands.DeleteCertificate;

public class DeleteCertificateCommandHandler
    : IRequestHandler<
        DeleteCertificateCommand,
        Result>
{
    private readonly ICertificateRepository
        _certificateRepository;

    public DeleteCertificateCommandHandler(
        ICertificateRepository certificateRepository)
    {
        _certificateRepository =
            certificateRepository;
    }

    public async Task<Result>
        Handle(
            DeleteCertificateCommand request,
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

        _certificateRepository.Delete(certificate);

        await _certificateRepository
            .SaveChangesAsync();

        return Result.Success();
    }
}
