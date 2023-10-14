using NUnit.Framework;

namespace AlighnSolution.Email.Tests;

public class TestSendEmail
{
    [TestCase]
    public async Task TestEmailSending()
    {
        var emailService = new EmailService("127.0.0.1", 1025, "bE8fbAe9gzDxnwYyISYl0A");
        var keyValuePair = new Dictionary<string, string>()
        {
            {"Email_Verification_Token", "552233"},
            {"Username", "Alighn"}
        };
        var message = "Hello {Username},\n Your email confirmation token is: {Email_Verification_Token} \n Best regards";
        var emailMessage = new EmailMessage(keyValuePair, message);
        await emailService.Send("alighndev@protonmail.com", emailMessage.MessageBody, "Your email confirmation token", 
            "Alighn.dev", "info@alighn.dev");
    }
}