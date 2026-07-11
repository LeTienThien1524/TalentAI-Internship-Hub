using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Users.DTOs;

namespace TalentAI.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery
    : IRequest<Result<UserDto>>
{
    public Guid Id { get; set; }

    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
}
