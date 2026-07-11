using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Infrastructure.Data;
using TalentAI.Infrastructure.Services;
using TalentAI.Application.Interfaces;
using TalentAI.Domain.Repositories;
using TalentAI.Infrastructure.Repositories;
using TalentAI.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace TalentAI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TalentAIDbContext>(
            options =>
            {
                options.UseSqlServer(
                    configuration
                        .GetConnectionString(
                            "DefaultConnection"));
            });

        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        services.AddScoped<IPasswordHasher, PasswordHasher>();

        services.AddScoped<IJwtService, JwtService>();

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddScoped<IEmailService, EmailService>();

        services.AddScoped<IFileStorageService, FileStorageService>();

        services.AddScoped<IAIService, AIService>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IRoleRepository, RoleRepository>();

        services.AddScoped<IUserRoleRepository, UserRoleRepository>();

        services.AddScoped<IProvinceRepository, ProvinceRepository>();

        services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();

        services.AddScoped<ISkillRepository, SkillRepository>();

        services.AddScoped<ICandidateRepository, CandidateRepository>();

        services.AddScoped<ICompanyRepository, CompanyRepository>();

        services.AddScoped<IJobPostingRepository, JobPostingRepository>();

        services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();

        services.AddScoped<IResumeRepository, ResumeRepository>();

        services.AddScoped<IApplicationHistoryRepository, ApplicationHistoryRepository>();

        services.AddScoped<IInterviewRepository, InterviewRepository>();

        services.AddScoped<INotificationRepository, NotificationRepository>();

        services.AddScoped<IAIParsedResumeRepository, AIParsedResumeRepository>();

        services.AddScoped<IAIMatchScoreRepository, AIMatchScoreRepository>();

        services.AddScoped<IDashboardRepository, DashboardRepository>();

        services.AddScoped<IEducationRepository, EducationRepository>();

        services.AddScoped<ICertificateRepository, CertificateRepository>();

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        services.AddScoped<IPasswordResetTokenRepository, PasswordResetTokenRepository>();

        services.AddHttpContextAccessor();

        return services;
    }
}