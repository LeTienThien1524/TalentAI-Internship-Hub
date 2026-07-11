using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAI.Application.Interfaces;

public interface IAIService
{
    Task<string> ParseResumeAsync(string resumeText);

    Task<decimal> CalculateMatchScoreAsync(
        string resumeContent,
        string jobDescription);
}
