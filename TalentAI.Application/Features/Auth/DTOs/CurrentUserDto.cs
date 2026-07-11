using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAI.Application.Features.Auth.DTOs;

public class CurrentUserDto
{
    public Guid UserId { get; set; }

    public string Email { get; set; } = string.Empty;

    public List<string> Roles { get; set; } = [];
}
