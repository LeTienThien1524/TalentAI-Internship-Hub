using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Companies.DTOs;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Companies.Queries.GetCompanyProfile;

public class GetCompanyProfileQueryHandler
    : IRequestHandler<
        GetCompanyProfileQuery,
        Result<CompanyDto>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ICurrentUserService _currentUser;

    public GetCompanyProfileQueryHandler(
        ICompanyRepository companyRepository,
        ICurrentUserService currentUser)
    {
        _companyRepository = companyRepository;
        _currentUser = currentUser;
    }

    public async Task<Result<CompanyDto>> Handle(
        GetCompanyProfileQuery request,
        CancellationToken cancellationToken)
    {
        var company =
            await _companyRepository.GetByUserIdAsync(
                _currentUser.UserId);

        if (company == null)
        {
            return Result<CompanyDto>.Failure(
                "Company profile not found");
        }

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
