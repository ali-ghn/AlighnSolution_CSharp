using System.Text.RegularExpressions;

namespace AlighnSolution.Email;

public class EmailMessage
{
    public string MessageBody { get; }

    public EmailMessage(Dictionary<string, string> keyValuePair, string message)
    {
        Regex re = new(@"\{(\w*?)\}", RegexOptions.Compiled);
        MessageBody = re.Replace(message, delegate(Match match)
        {
            var key = match.Groups[1].Value;
            return keyValuePair[key];
        });
    }
}