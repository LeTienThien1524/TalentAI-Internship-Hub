using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;

namespace TalentAI.Application.Features.AI.Queries.GetRecommendedJobs;

public class GetRecommendedJobsQuery
    : IRequest<Result<List<Guid>>>
{
}
