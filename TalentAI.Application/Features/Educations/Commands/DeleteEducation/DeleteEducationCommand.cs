using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;

namespace TalentAI.Application.Features.Educations.Commands.DeleteEducation;

public record DeleteEducationCommand(
    Guid Id)
    : IRequest<Result>;
