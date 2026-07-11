using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.JobCategories.DTOs;

namespace TalentAI.Application.Features.JobCategories.Queries.GetJobCategories;

public record GetJobCategoriesQuery
    : IRequest<Result<List<JobCategoryDto>>>;
