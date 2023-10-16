using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.FileProviders;
using ZstdSharp.Unsafe;

namespace AlighnSolution.Email;

public interface IEmailService
{
    Task Send(string to, string message, string subject, string title, string from);
}

public class EmailService : IEmailService
{
    string Hostname { get; set; }
    int Port { get; set; }
    private string Secret { get; set; }
    private ILogger<EmailService> _logger;

    public EmailService(string host, int port, string secret, ILogger<EmailService> logger)
    {
        Hostname = host;
        Port = port;
        Secret = secret;
        _logger = logger;
    }


    public async Task<string> LoadTemplate(string templateName)
    {
        try
        {
            var sr = new StreamReader($"{Directory.GetCurrentDirectory()}/assets/{templateName}.html");
            return await sr.ReadToEndAsync();
        }
        catch (IOException e)
        {
            _logger.Log(LogLevel.Error, $"{DateTime.UtcNow} - {e.Message}");
            throw;
        }
    }

    public async Task Send(string to, string message, string subject, string title, string from)
    {
        var mail = new MailMessage();
        mail.Subject = subject;
        mail.From = new MailAddress(from, title);
        mail.To.Add(new MailAddress(to));
        mail.Body = message;
        mail.IsBodyHtml = true;
        using var smtpClient = new SmtpClient(Hostname, Port);
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
        smtpClient.Credentials = new System.Net.NetworkCredential(from, Secret);
        await smtpClient.SendMailAsync(mail);
        return;
    }
}