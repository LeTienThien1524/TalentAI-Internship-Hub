using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Entities.Jobs;

namespace TalentAI.Domain.Entities.Metadata;

public class JobCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<JobPosting> JobPostings { get; set; }
        = new List<JobPosting>();
}
