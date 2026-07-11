using MediatR;

using TalentAI.Application.Common.Models;
using TalentAI.Application.Interfaces;

using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Auth.Commands.ChangePassword;

public class ChangePasswordCommandHandler
    : IRequestHandler<ChangePasswordCommand, Result>
{
    private readonly ICurrentUserService _currentUser;

    private readonly IUserRepository _userRepository;

    private readonly IPasswordHasher _passwordHasher;

    private readonly IUnitOfWork _unitOfWork;

    public ChangePasswordCommandHandler(
        ICurrentUserService currentUser,
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork)
    {
        _currentUser = currentUser;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(
        ChangePasswordCommand request,
        CancellationToken cancellationToken)
    {
        if (_currentUser.UserId == Guid.Empty)
        {
            return Result.Unauthorized();
        }

        var user = await _userRepository
            .GetByIdAsync(_currentUser.UserId);

        if (user is null)
        {
            return Result.NotFound("User not found.");
        }

        if (!_passwordHasher.VerifyPassword(
            request.CurrentPassword,
            user.PasswordHash))
        {
            return Result.Failure("Current password is incorrect.");
        }

        user.PasswordHash = _passwordHasher
            .HashPassword(request.NewPassword);

        _userRepository.Update(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success("Password changed successfully.");
    }
}