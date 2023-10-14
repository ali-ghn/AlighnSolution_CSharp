namespace AlighnSolution.Email;

public class EmailMessage
{
    public string MessageBody { get; }

    public EmailMessage(Dictionary<string, string> keyValuePair, string message)
    {
        foreach (var word in message.Split(" "))
        {
            if (word.StartsWith("{") && word.EndsWith("}"))
                if (message.Split(" ").Last() != word)
                {
                    var sanitizedKey = word.Replace("{", "").Replace("}", "");
                    MessageBody += keyValuePair.Single(pair => pair.Key == sanitizedKey).Value + " ";
                }
                else
                {
                    var sanitizedKey = word.Replace("{", "").Replace("}", "");
                    MessageBody += keyValuePair.Single(pair => pair.Key == sanitizedKey).Value + " ";
                }
            else
                if (message.Split(" ").Last() != word)
                    MessageBody += word + " ";
                else
                    MessageBody += word;
        }
    }
}