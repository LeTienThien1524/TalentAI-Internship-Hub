using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IDashboardRepository
{
    Task<int> GetTotalCandidatesAsync();

    Task<int> GetTotalCompaniesAsync();

    Task<int> GetTotalJobsAsync();

    Task<int> GetTotalApplicationsAsync();

    Task<int> GetTotalInterviewsAsync();
}
