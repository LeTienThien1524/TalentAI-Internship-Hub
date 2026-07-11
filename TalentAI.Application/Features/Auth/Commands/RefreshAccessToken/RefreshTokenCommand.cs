using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Auth.DTOs;

namespace TalentAI.Application.Features.Auth.Commands.RefreshAccessToken;

public class RefreshTokenCommand
    : IRequest<Result<AuthResponseDto>>
{
    public string RefreshToken { get; set; } = string.Empty;
}
