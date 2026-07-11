using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using TalentAI.Domain.Entities.Identity;
using TalentAI.Domain.Entities.Metadata;

namespace TalentAI.Infrastructure.Data;

public static class DbInitializer
{
    // 🌟 Hàm helper đọc file từ bộ nhớ DLL (Embedded Resource)
    private static async Task<string> ReadEmbeddedJsonAsync(string fileName)
    {
        var assembly = typeof(DbInitializer).Assembly;

        // Tự động tìm file dựa theo đuôi tên file (Ví dụ: roles.json)
        var resourceName = assembly.GetManifestResourceNames()
            .FirstOrDefault(str => str.EndsWith(fileName, StringComparison.OrdinalIgnoreCase));

        if (string.IsNullOrEmpty(resourceName))
        {
            throw new FileNotFoundException($"[TalentAI Lỗi] Không tìm thấy file Embedded Resource nào có tên: {fileName} trong project Infrastructure!");
        }

        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null) throw new NullReferenceException($"Không thể mở stream cho file: {fileName}");

        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }

    public static async Task SeedMasterDataAsync(TalentAIDbContext context)
    {
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        // 🌟 1. SEED ROLES
        if (!await context.Roles.AnyAsync())
        {
            var json = await ReadEmbeddedJsonAsync("roles.json");
            var data = JsonSerializer.Deserialize<List<Role>>(json, options);
            if (data != null && data.Any())
            {
                await context.Roles.AddRangeAsync(data);
                await context.SaveChangesAsync();
            }
        }

        // 🌟 2. SEED PROVINCES
        if (!await context.Provinces.AnyAsync())
        {
            var json = await ReadEmbeddedJsonAsync("provinces.json");
            var data = JsonSerializer.Deserialize<List<Province>>(json, options);
            if (data != null && data.Any())
            {
                using var tx = await context.Database.BeginTransactionAsync();
                try
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Provinces] ON;");
                    await context.Provinces.AddRangeAsync(data);
                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Provinces] OFF;");
                    await tx.CommitAsync();
                }
                catch
                {
                    await tx.RollbackAsync();
                    throw;
                }
            }
        }

        // 🌟 3. SEED JOB CATEGORIES
        if (!await context.JobCategories.AnyAsync())
        {
            var json = await ReadEmbeddedJsonAsync("job_categories.json");
            var data = JsonSerializer.Deserialize<List<JobCategory>>(json, options);
            if (data != null && data.Any())
            {
                using var tx = await context.Database.BeginTransactionAsync();
                try
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [JobCategories] ON;");
                    await context.JobCategories.AddRangeAsync(data);
                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [JobCategories] OFF;");
                    await tx.CommitAsync();
                }
                catch
                {
                    await tx.RollbackAsync();
                    throw;
                }
            }
        }

        // 🌟 4. SEED SKILLS
        if (!await context.Skills.AnyAsync())
        {
            var json = await ReadEmbeddedJsonAsync("skills.json");
            var data = JsonSerializer.Deserialize<List<Skill>>(json, options);
            if (data != null && data.Any())
            {
                using var tx = await context.Database.BeginTransactionAsync();
                try
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Skills] ON;");
                    await context.Skills.AddRangeAsync(data);
                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Skills] OFF;");
                    await tx.CommitAsync();
                }
                catch
                {
                    await tx.RollbackAsync();
                    throw;
                }
            }
        }
    }
}