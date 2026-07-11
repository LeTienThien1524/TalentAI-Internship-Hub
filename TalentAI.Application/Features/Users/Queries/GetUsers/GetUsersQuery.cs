using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Users.DTOs;

namespace TalentAI.Application.Features.Users.Queries.GetUsers;

public class GetUsersQuery
    : IRequest<Result<List<UserDto>>>
{
}
