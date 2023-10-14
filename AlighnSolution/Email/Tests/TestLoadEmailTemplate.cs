using AlighnSolution.Email.Templates;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace AlighnSolution.Email.Tests;

public class TestLoadEmailTemplate
{
    [TestCase]
    public async Task TestEmailTemplateLoading()
    {
        var emailService = new EmailService("127.0.0.1", 1025, "bE8fbAe9gzDxnwYyISYl0A", new Logger<EmailService>(new NullLoggerFactory()));
        var message = await emailService.LoadTemplate(EmailTemplates.EmailConfirmationTemplate);
        Console.WriteLine(message);
    }
}