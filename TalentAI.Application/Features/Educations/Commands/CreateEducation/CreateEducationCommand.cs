using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Educations.DTOs;

namespace TalentAI.Application.Features.Educations.Commands.CreateEducation;

public record CreateEducationCommand(
    Guid CandidateId,
    string University,
    string Major,
    string Degree,
    decimal? GPA,
    int StartYear,
    int? EndYear)
    : IRequest<Result<EducationDto>>;
