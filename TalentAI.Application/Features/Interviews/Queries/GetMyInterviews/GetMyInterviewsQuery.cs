using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Interviews.DTOs;

namespace TalentAI.Application.Features.Interviews.Queries.GetMyInterviews;

public record GetMyInterviewsQuery
    : IRequest<Result<List<InterviewDto>>>;
