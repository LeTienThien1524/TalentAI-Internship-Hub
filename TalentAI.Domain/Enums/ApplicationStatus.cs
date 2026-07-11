using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAI.Domain.Enums;

public enum ApplicationStatus
{
    Pending = 0,
    Reviewing = 1,
    Shortlisted = 2,
    Interviewing = 3,
    Offered = 4,
    Rejected = 5
}
