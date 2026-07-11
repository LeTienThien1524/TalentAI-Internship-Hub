using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Metadata;

namespace TalentAI.Domain.Repositories;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> GetAllAsync();

    Task<Skill?> GetByIdAsync(int id);

    Task<bool> ExistsByNameAsync(string name);

    Task AddAsync(Skill skill);

    void Update(Skill skill);

    void Delete(Skill skill);

    Task SaveChangesAsync();
}
