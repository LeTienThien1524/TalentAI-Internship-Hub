using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;

namespace TalentAI.Application.Features.Auth.Commands.ForgotPassword;

public class ForgotPasswordCommand
    : IRequest<Result>
{
    public string Email { get; set; } = string.Empty;
}
