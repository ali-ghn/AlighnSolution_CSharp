using System.Net.Mail;

namespace AlighnSolution.Email;

public interface IEmailService
{
    Task Send(string to, string message, string title, string from);
}

public class EmailService : IEmailService
{
    string Hostname { get; set; }
     int Port { get; set; }
    private string Secret { get; set; }
    public EmailService(string host, int port, string secret)
    {
        Hostname = host;
        Port = port;
        Secret = secret;
    }

    public async Task Send(string to, string message, string title, string from)
    {   
        var mail = new MailMessage();
        mail.From = new MailAddress(from, title);
        mail.To.Add(new MailAddress(to));
        mail.Body = message;
        using var smtpClient = new SmtpClient(Hostname, Port);
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new System.Net.NetworkCredential(from, Secret);
        await smtpClient.SendMailAsync(mail);
        return;
    }
}