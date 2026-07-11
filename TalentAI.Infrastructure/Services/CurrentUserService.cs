using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TalentAI.Application.Interfaces;

namespace TalentAI.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId
    {
        get
        {
            var value = _httpContextAccessor.HttpContext?
                .User?
                .FindFirst(ClaimTypes.NameIdentifier)?
                .Value;

            return Guid.TryParse(value, out var id)
                ? id
                : Guid.Empty;
        }
    }

    public string Email
    {
        get
        {
            return _httpContextAccessor.HttpContext?
                .User?
                .FindFirst(ClaimTypes.Email)?
                .Value ?? string.Empty;
        }
    }

    public List<string> Roles
    {
        get
        {
            return _httpContextAccessor.HttpContext?
                .User?
                .FindAll(ClaimTypes.Role)?
                .Select(x => x.Value)
                .ToList()
                ?? new List<string>();
        }
    }

    public bool IsAuthenticated
    {
        get => UserId != Guid.Empty;
    }
}