using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Domain.Entities.Jobs;
using TalentAI.Domain.Entities.Profiles;

namespace TalentAI.Domain.Entities.Metadata;

public class Province
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<Candidate> Candidates { get; set; }
        = new List<Candidate>();

    public ICollection<Company> Companies { get; set; }
        = new List<Company>();

    public ICollection<JobPosting> JobPostings { get; set; }
        = new List<JobPosting>();
}
