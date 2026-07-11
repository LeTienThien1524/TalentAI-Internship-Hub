using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobCategories.DTOs;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.JobCategories.Queries.GetJobCategoryById;

public class GetJobCategoryByIdQueryHandler
    : IRequestHandler<
        GetJobCategoryByIdQuery,
        Result<JobCategoryDto>>
{
    private readonly IJobCategoryRepository _jobCategoryRepository;

    private readonly IMapper _mapper;

    public GetJobCategoryByIdQueryHandler(
        IJobCategoryRepository jobCategoryRepository,
        IMapper mapper)
    {
        _jobCategoryRepository = jobCategoryRepository;
        _mapper = mapper;
    }

    public async Task<Result<JobCategoryDto>> Handle(
        GetJobCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var jobCategory =
            await _jobCategoryRepository.GetByIdAsync(request.Id);

        if (jobCategory is null)
        {
            return Result<JobCategoryDto>.NotFound(
                "Job category not found.");
        }

        var dto =
            _mapper.Map<JobCategoryDto>(jobCategory);

        return Result<JobCategoryDto>.Success(dto);
    }
}
