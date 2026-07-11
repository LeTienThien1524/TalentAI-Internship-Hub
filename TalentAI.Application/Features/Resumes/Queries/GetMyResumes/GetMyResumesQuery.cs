using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Resumes.DTOs;

namespace TalentAI.Application.Features.Resumes.Queries.GetMyResumes;

public class GetMyResumesQuery
    : IRequest<Result<List<ResumeDto>>>
{
}
