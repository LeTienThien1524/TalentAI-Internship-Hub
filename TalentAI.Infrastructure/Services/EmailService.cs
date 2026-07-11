using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TalentAI.Application.Interfaces;

namespace TalentAI.Infrastructure.Services;

public class EmailService : IEmailService
{
    public async Task SendEmailAsync(
        string to,
        string subject,
        string body)
    {
        // TODO:
        // Sau này tích hợp SMTP / MailKit / SendGrid

        await Task.CompletedTask;
    }
}
