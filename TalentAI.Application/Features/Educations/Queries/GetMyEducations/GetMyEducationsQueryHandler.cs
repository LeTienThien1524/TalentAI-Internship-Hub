using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Educations.DTOs;

using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Educations.Queries.GetMyEducations;

public class GetMyEducationsQueryHandler
    : IRequestHandler<
        GetMyEducationsQuery,
        Result<List<EducationDto>>>
{
    private readonly IEducationRepository
        _educationRepository;

    public GetMyEducationsQueryHandler(
        IEducationRepository educationRepository)
    {
        _educationRepository = educationRepository;
    }

    public async Task<Result<List<EducationDto>>>
        Handle(
            GetMyEducationsQuery request,
            CancellationToken cancellationToken)
    {
        var educations =
            await _educationRepository
                .GetByCandidateIdAsync(
                    request.CandidateId);

        var result = educations
            .Select(x => new EducationDto
            {
                Id = x.Id,
                University = x.University,
                Major = x.Major,
                Degree = x.Degree,
                GPA = x.GPA,
                StartYear = x.StartYear,
                EndYear = x.EndYear
            })
            .ToList();

        return Result<List<EducationDto>>
            .Success(result);
    }
}
