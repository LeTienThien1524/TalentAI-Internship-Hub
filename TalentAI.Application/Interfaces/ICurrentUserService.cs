using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAI.Application.Interfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }

    string Email { get; }

    List<string> Roles { get; }

    bool IsAuthenticated { get; }
}
