using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Educations.DTOs;

namespace TalentAI.Application.Features.Educations.Queries.GetMyEducations;

public record GetMyEducationsQuery(
    Guid CandidateId)
    : IRequest<Result<List<EducationDto>>>;
