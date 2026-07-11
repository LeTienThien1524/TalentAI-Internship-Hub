using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;

namespace TalentAI.Application.Features.Educations.Commands.UpdateEducation;

public record UpdateEducationCommand(
    Guid Id,
    string University,
    string Major,
    string Degree,
    decimal? GPA,
    int StartYear,
    int? EndYear)
    : IRequest<Result>;
