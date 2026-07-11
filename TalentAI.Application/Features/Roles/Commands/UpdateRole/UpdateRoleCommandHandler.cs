using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Roles.Commands.UpdateRole;

public class UpdateRoleCommandHandler
    : IRequestHandler<UpdateRoleCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoleCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        UpdateRoleCommand request,
        CancellationToken cancellationToken)
    {
        var role = await _unitOfWork.Roles
            .GetByIdAsync(request.Id);

        if (role is null)
        {
            return false;
        }

        role.Name = request.Name;
        role.NormalizedName = request.Name.ToUpperInvariant();

        _unitOfWork.Roles.Update(role);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
