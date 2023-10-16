using AlighnSolution.Email.Templates;
using NUnit.Framework;

namespace AlighnSolution.Email.Tests;

public class TestSendEmail
{
    [TestCase]
    public async Task TestEmailSending()
    {
        var emailService = new EmailService("127.0.0.1", 1025, "bE8fbAe9gzDxnwYyISYl0A", null);
        var keyValuePair = new Dictionary<string, string>()
        {
            {"Email", "alighndev@protonmail.com"},
            {"EmailConfirmationToken", "123456"}
        };
        var message = await emailService.LoadTemplate(EmailTemplates.EmailConfirmationTemplate);
        var emailMessage = new EmailMessage(keyValuePair, message);
        await emailService.Send("alighndev@protonmail.com", emailMessage.MessageBody, "Your email confirmation token", 
            "Alighn.dev", "info@alighn.dev");
    }
}