using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Application.Interfaces;

namespace TalentAI.Infrastructure.Services;

public class FileStorageService
    : IFileStorageService
{
    public async Task<string> UploadFileAsync(
        Stream fileStream,
        string fileName)
    {
        // TODO:
        // Azure Blob
        // AWS S3
        // Local Storage

        await Task.CompletedTask;

        return $"uploads/{fileName}";
    }

    public async Task DeleteFileAsync(
        string filePath)
    {
        // TODO

        await Task.CompletedTask;
    }
}
