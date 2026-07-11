using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Companies.DTOs;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Entities.Profiles;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Companies.Commands.UpsertCompanyProfile;

public class UpsertCompanyProfileCommandHandler
    : IRequestHandler<
        UpsertCompanyProfileCommand,
        Result<CompanyDto>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUser;

    public UpsertCompanyProfileCommandHandler(
        ICompanyRepository companyRepository,
        IUnitOfWork unitOfWork,
        ICurrentUserService currentUser)
    {
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
    }

    public async Task<Result<CompanyDto>> Handle(
        UpsertCompanyProfileCommand request,
        CancellationToken cancellationToken)
    {
        var userId = _currentUser.UserId;

        var company =
            await _companyRepository.GetByUserIdAsync(userId);

        if (company == null)
        {
            company = new Company
            {
                UserId = userId,
                ProvinceId = request.ProvinceId,
                CompanyName = request.CompanyName,
                TaxCode = request.TaxCode,
                Website = request.Website,
                LogoUrl = request.LogoUrl,
                Description = request.Description,
                IsVerified = false
            };

            await _companyRepository.AddAsync(company);
        }
        else
        {
            company.ProvinceId = request.ProvinceId;
            company.CompanyName = request.CompanyName;
            company.TaxCode = request.TaxCode;
            company.Website = request.Website;
            company.LogoUrl = request.LogoUrl;
            company.Description = request.Description;

            _companyRepository.Update(company);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<CompanyDto>.Success(
            new CompanyDto
            {
                Id = company.Id,
                UserId = company.UserId,
                ProvinceId = company.ProvinceId ?? 64,
                CompanyName = company.CompanyName,
                TaxCode = company.TaxCode,
                Website = company.Website,
                LogoUrl = company.LogoUrl,
                Description = company.Description,
                IsVerified = company.IsVerified
            });
    }
}
