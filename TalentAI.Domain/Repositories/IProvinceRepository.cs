using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Entities.Metadata;

namespace TalentAI.Domain.Repositories;

public interface IProvinceRepository
{
    Task<IEnumerable<Province>> GetAllAsync();

    Task<Province?> GetByIdAsync(int id);

    Task<bool> ExistsByNameAsync(string name);

    Task AddAsync(Province province);

    void Update(Province province);

    void Delete(Province province);

    Task SaveChangesAsync();
}
