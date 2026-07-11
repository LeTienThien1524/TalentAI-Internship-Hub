using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TalentAI.Application.Common.Models;
using TalentAI.Domain.Entities.Identity;
using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler
    : IRequestHandler<
        CreateRoleCommand,
        Result<Guid>>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoleCommandHandler(
        IRoleRepository roleRepository,
        IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        CreateRoleCommand request,
        CancellationToken cancellationToken)
    {
        var existed =
            await _roleRepository
                .GetByNameAsync(request.Name);

        if (existed is not null)
        {
            return Result<Guid>
                .Failure("Role already exists");
        }

        var role = new Role
        {
            Name = request.Name,
            NormalizedName =
                request.Name.ToUpper()
        };

        await _roleRepository.AddAsync(role);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return Result<Guid>
            .Success(role.Id);
    }
}
