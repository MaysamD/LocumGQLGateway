using System.Net;
using System.Net.Mail;
using System.Text.Json;
using LocumApp.Domain.Models.Notifications;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NotificationProcessor.Models;
using NotificationProcessor.Services.Interfaces;

namespace NotificationProcessor.Services.Implementations;

public class EmailNotificationSender : INotificationSender
{
    private readonly EmailSettings _emailSettings;
    private readonly ILogger<EmailNotificationSender> _logger;


    public EmailNotificationSender(ILogger<EmailNotificationSender> logger, IOptions<EmailSettings> emailSettings)
    {
        _logger = logger;
        _emailSettings = emailSettings.Value;
    }

    public async Task SendAsync(Notification notification)
    {
        _logger.LogInformation("Sending email notification");
        // check if the EmailRecipient is provided
        if (string.IsNullOrWhiteSpace(notification.EmailRecipient))
            throw new ArgumentNullException(nameof(notification.EmailRecipient), "Email recipient is required");

        using var client = new SmtpClient(_emailSettings.SmtpHost, _emailSettings.SmtpPort)
        {
            Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.Password),
            EnableSsl = true
        };

        var isBodyHtml = false;
        var body = string.Empty;
        if (notification.NotificationTemplate is not null)
        {
            isBodyHtml = true;
            var resultHtml = "";
            var templatePath = Path.Combine(AppContext.BaseDirectory, "EmailTemplates", "WelcomeTemplate.html");
            var htmlTemplate = File.ReadAllText(templatePath);

            if (notification.Metadata != null) resultHtml = ReplaceTemplateVariables(htmlTemplate, notification.Metadata);

            body = resultHtml;
        }
        else if (!string.IsNullOrWhiteSpace(notification.HtmlBody))
        {
            isBodyHtml = true;

            body = notification.HtmlBody;
        }
        else
        {
            body = notification.Message;
        }

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
            Subject = notification.Title,
            Body = body,
            IsBodyHtml = isBodyHtml
        };
        mailMessage.To.Add(notification.EmailRecipient);

        await client.SendMailAsync(mailMessage);
    }

    public string ReplaceTemplateVariables(string htmlTemplate, string jsonMetadata)
    {
        var metadata = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonMetadata);
        if (metadata == null) return htmlTemplate;

        foreach (var kv in metadata)
        {
            var placeholder = $"{{{{{kv.Key}}}}}"; // {{VariableName}}
            htmlTemplate = htmlTemplate.Replace(placeholder, kv.Value);
        }

        return htmlTemplate;
    }
}