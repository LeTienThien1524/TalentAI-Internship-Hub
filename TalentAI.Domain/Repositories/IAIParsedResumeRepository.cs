using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Resumes;

namespace TalentAI.Domain.Repositories;

public interface IAIParsedResumeRepository
    : IGenericRepository<AIParsedResume>
{
    Task<AIParsedResume?>
        GetByResumeIdAsync(Guid resumeId);
}
