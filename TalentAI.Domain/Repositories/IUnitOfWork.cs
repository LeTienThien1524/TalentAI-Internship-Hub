using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAI.Domain.Repositories;

public interface IUnitOfWork
{
    IUserRepository Users { get; }

    IRoleRepository Roles { get; }

    IUserRoleRepository UserRoles { get; }

    IProvinceRepository Provinces { get; }

    ISkillRepository Skills { get; }

    IJobCategoryRepository JobCategories { get; }

    ICandidateRepository Candidates { get; }

    IJobPostingRepository JobPostings { get; }

    ICompanyRepository Companies { get; }

    IResumeRepository Resumes { get; }

    IJobApplicationRepository JobApplications { get; }

    IApplicationHistoryRepository ApplicationHistories { get; }

    IInterviewRepository Interviews { get; }

    INotificationRepository Notifications { get; }

    IAIParsedResumeRepository AIParsedResumes { get; }

    IAIMatchScoreRepository AIMatchScores { get; }

    IRefreshTokenRepository RefreshTokens { get; }

    IPasswordResetTokenRepository PasswordResetTokens { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}