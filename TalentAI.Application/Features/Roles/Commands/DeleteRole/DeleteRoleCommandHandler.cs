using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using TalentAI.Domain.Repositories;

namespace TalentAI.Application.Features.Roles.Commands.DeleteRole;

public class DeleteRoleCommandHandler
    : IRequestHandler<DeleteRoleCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRoleCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(
        DeleteRoleCommand request,
        CancellationToken cancellationToken)
    {
        var role = await _unitOfWork.Roles
            .GetByIdAsync(request.Id);

        if (role is null)
        {
            return false;
        }

        _unitOfWork.Roles.Delete(role);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
