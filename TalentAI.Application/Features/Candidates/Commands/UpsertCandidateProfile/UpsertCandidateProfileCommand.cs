using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Candidates.DTOs;

namespace TalentAI.Application.Features.Candidates.Commands;

public class UpsertCandidateProfileCommand
    : IRequest<Result<CandidateDto>>
{
    public string FullName { get; set; } = string.Empty;

    public DateOnly? DateOfBirth { get; set; }

    public int ProvinceId { get; set; }

    public string? AvatarUrl { get; set; }
}
