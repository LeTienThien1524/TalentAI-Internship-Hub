using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;

namespace TalentAI.Application.Features.AI.Commands.ParseResume;

public class ParseResumeCommand
    : IRequest<Result<ParsedResumeDto>>
{
    public Guid ResumeId { get; set; }
}
