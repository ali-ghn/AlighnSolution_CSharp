using NUnit.Framework;
namespace AlighnSolution.Email.Tests;

public class TestEmailMessageReplacement
{
    [TestCase]
    public void TestEmailMessageMessageReplacement()
    {
        var message = "Hello {name} This is a {name2}";
        Dictionary<string, string> values = new Dictionary<string, string>()
        {
            {"name","Ali"},
            {"name2", "test"}
        };
        var emailMessage = new EmailMessage(values, message);
        Console.WriteLine(emailMessage.MessageBody);
    }
}