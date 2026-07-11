using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Application.Interfaces;

namespace TalentAI.Infrastructure.Services;

public class AIService
    : IAIService
{
    public async Task<string> ParseResumeAsync(
        string resumeText)
    {
        // TODO:
        // OpenAI
        // Gemini
        // Azure AI

        await Task.CompletedTask;

        return resumeText;
    }

    public async Task<decimal> CalculateMatchScoreAsync(
        string resumeContent,
        string jobDescription)
    {
        // TODO

        await Task.CompletedTask;

        return 0;
    }
}
