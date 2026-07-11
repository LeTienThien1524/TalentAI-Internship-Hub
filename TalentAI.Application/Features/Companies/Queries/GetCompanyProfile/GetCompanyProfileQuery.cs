using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Companies.DTOs;

namespace TalentAI.Application.Features.Companies.Queries.GetCompanyProfile;

public class GetCompanyProfileQuery
    : IRequest<Result<CompanyDto>>
{
}
