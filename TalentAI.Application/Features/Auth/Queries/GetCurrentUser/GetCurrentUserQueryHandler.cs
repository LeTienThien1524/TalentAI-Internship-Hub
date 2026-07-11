using AutoMapper;
using MediatR;

using TalentAI.Application.Common.Models;
using TalentAI.Application.Features.Auth.DTOs;
using TalentAI.Application.Interfaces;

using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Auth.Queries.GetCurrentUser;

public class GetCurrentUserQueryHandler
    : IRequestHandler<GetCurrentUserQuery, Result<CurrentUserDto>>
{
    private readonly ICurrentUserService _currentUser;

    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;

    public GetCurrentUserQueryHandler(
        ICurrentUserService currentUser,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _currentUser = currentUser;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result<CurrentUserDto>> Handle(
        GetCurrentUserQuery request,
        CancellationToken cancellationToken)
    {
        if (_currentUser.UserId == Guid.Empty)
        {
            return Result<CurrentUserDto>.Unauthorized();
        }

        var user = await _userRepository
            .GetByIdWithRolesAsync(_currentUser.UserId);

        if (user is null)
        {
            return Result<CurrentUserDto>.NotFound("User not found.");
        }

        var dto = _mapper.Map<CurrentUserDto>(user);

        dto.Roles = user.UserRoles
            .Select(x => x.Role.Name)
            .ToList();

        return Result<CurrentUserDto>.Success(dto);
    }
}