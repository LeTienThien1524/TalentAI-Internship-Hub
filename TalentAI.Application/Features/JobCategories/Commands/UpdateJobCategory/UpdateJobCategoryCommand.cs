using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Application.Common.Models;

namespace TalentAI.Application.Features.JobCategories.Commands.UpdateJobCategory;

public class UpdateJobCategoryCommand : IRequest<Result>
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
