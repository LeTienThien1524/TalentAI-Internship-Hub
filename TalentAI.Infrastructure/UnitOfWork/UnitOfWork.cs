using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Domain.Repositories;
using TalentAI.Infrastructure.Data;

namespace TalentAI.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly TalentAIDbContext _context;

    public IUserRepository Users { get; }

    public IRoleRepository Roles { get; }

    public IUserRoleRepository UserRoles { get; }

    public IProvinceRepository Provinces { get; }

    public ISkillRepository Skills { get; }

    public IJobCategoryRepository JobCategories { get; }

    public ICandidateRepository Candidates { get; }

    public IJobPostingRepository JobPostings { get; }

    public ICompanyRepository Companies { get; }

    public IResumeRepository Resumes { get; }

    public IJobApplicationRepository JobApplications { get; }

    public IApplicationHistoryRepository ApplicationHistories { get; }

    public IInterviewRepository Interviews { get; }

    public INotificationRepository Notifications { get; }

    public IAIParsedResumeRepository AIParsedResumes { get; }

    public IAIMatchScoreRepository AIMatchScores { get; }

    public IRefreshTokenRepository RefreshTokens { get; }

    public IPasswordResetTokenRepository PasswordResetTokens { get; }

    public UnitOfWork(
    TalentAIDbContext context,
    IUserRepository userRepository,
    IRoleRepository roleRepository,
    IUserRoleRepository userRoleRepository,
    IProvinceRepository provinceRepository,
    ISkillRepository skillRepository,
    IJobCategoryRepository jobCategoryRepository,
    ICandidateRepository candidateRepository,
    ICompanyRepository companyRepository,
    IJobPostingRepository jobPostingRepository,
    IResumeRepository resumeRepository,
    IJobApplicationRepository jobApplicationRepository,
    IApplicationHistoryRepository applicationHistoryRepository,
    IInterviewRepository interviewRepository,
    INotificationRepository notificationRepository,
    IAIParsedResumeRepository aiParsedResumeRepository,
    IAIMatchScoreRepository aiMatchScoreRepository,
    IRefreshTokenRepository refreshTokenRepository,
    IPasswordResetTokenRepository passwordResetTokens)
    {
        _context = context;

        Users = userRepository;

        Roles = roleRepository;

        UserRoles = userRoleRepository;

        Provinces = provinceRepository;

        Skills = skillRepository;

        JobCategories = jobCategoryRepository;

        Candidates = candidateRepository;

        Companies = companyRepository;

        JobPostings = jobPostingRepository;

        Resumes = resumeRepository;

        JobApplications = jobApplicationRepository;

        ApplicationHistories = applicationHistoryRepository;

        Interviews = interviewRepository;

        Notifications = notificationRepository;

        AIParsedResumes = aiParsedResumeRepository;

        AIMatchScores = aiMatchScoreRepository;

        RefreshTokens = refreshTokenRepository;

        PasswordResetTokens = passwordResetTokens;
    }

    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context
            .SaveChangesAsync(cancellationToken);
    }
}
