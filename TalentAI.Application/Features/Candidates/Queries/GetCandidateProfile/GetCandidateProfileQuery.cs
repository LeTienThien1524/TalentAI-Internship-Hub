using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Candidates.DTOs;

namespace TalentAI.Application.Features.Candidates.Queries;

public class GetCandidateProfileQuery
    : IRequest<Result<CandidateDto>>
{
}
