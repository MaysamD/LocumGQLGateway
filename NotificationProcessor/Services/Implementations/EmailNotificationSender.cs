using System.Net;
using System.Net.Mail;
using System.Text.Json;
using LocumApp.Domain.Models.Notifications;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NotificationProcessor.Models;
using NotificationProcessor.Services.Interfaces;

namespace NotificationProcessor.Services.Implementations;

/// <summary>
///     Provides functionality to send email notifications using SMTP.
///     Supports sending plain text, HTML, or template-based emails.
/// </summary>
public class EmailNotificationSender : INotificationSender
{
    private readonly EmailSettings _emailSettings;
    private readonly ILogger<EmailNotificationSender> _logger;

    /// <summary>
    ///     Initializes a new instance of the <see cref="EmailNotificationSender" /> class.
    /// </summary>
    /// <param name="logger">The logger instance for logging messages.</param>
    /// <param name="emailSettings">The email settings configured via <see cref="IOptions{TOptions}" />.</param>
    public EmailNotificationSender(ILogger<EmailNotificationSender> logger, IOptions<EmailSettings> emailSettings)
    {
        _logger = logger;
        _emailSettings = emailSettings.Value;
    }

    /// <summary>
    ///     Sends an email notification based on the provided <see cref="Notification" /> details.
    /// </summary>
    /// <param name="notification">The notification object containing recipient, subject, body, and metadata.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if the email recipient, subject, or content is missing.
    /// </exception>
    /// <exception cref="ArgumentException">Thrown if the email recipient format is invalid.</exception>
    /// <exception cref="InvalidOperationException">Thrown if SMTP host or sender email is not configured.</exception>
    /// <exception cref="FileNotFoundException">Thrown if the email template file is missing.</exception>
    public async Task SendAsync(Notification notification)
    {
        _logger.LogInformation("Sending email notification");

        ValidateNotification(notification);
        ValidateEmailSettings();

        var body = BuildEmailBody(notification, out var isBodyHtml);

        using var client = CreateSmtpClient();
        var mailMessage = CreateMailMessage(notification, body, isBodyHtml);

        await client.SendMailAsync(mailMessage);
    }

    #region Private Helpers

    /// <summary>
    ///     Validates the notification object for required fields and correct email format.
    /// </summary>
    /// <param name="notification">The notification to validate.</param>
    /// <exception cref="ArgumentNullException">If recipient, title, or content is missing.</exception>
    /// <exception cref="ArgumentException">If recipient email format is invalid.</exception>
    private void ValidateNotification(Notification notification)
    {
        if (string.IsNullOrWhiteSpace(notification.EmailRecipient))
            throw new ArgumentNullException(nameof(notification.EmailRecipient), "Email recipient is required.");

        try
        {
            _ = new MailAddress(notification.EmailRecipient); // format validation
        }
        catch
        {
            throw new ArgumentException("Invalid email address format.", nameof(notification.EmailRecipient));
        }

        if (string.IsNullOrWhiteSpace(notification.Title))
            throw new ArgumentNullException(nameof(notification.Title), "Email subject is required.");

        if (string.IsNullOrWhiteSpace(notification.Message) &&
            string.IsNullOrWhiteSpace(notification.HtmlBody) &&
            notification.NotificationTemplate is null)
            throw new ArgumentNullException(nameof(notification.Message),
                "Email content is missing. Please provide a Message, HtmlBody, or NotificationTemplate.");
    }

    /// <summary>
    ///     Validates that SMTP settings are correctly configured.
    /// </summary>
    /// <exception cref="InvalidOperationException">If SMTP host or sender email is missing.</exception>
    private void ValidateEmailSettings()
    {
        if (string.IsNullOrWhiteSpace(_emailSettings.SmtpHost))
            throw new InvalidOperationException("SMTP host is not configured.");

        if (string.IsNullOrWhiteSpace(_emailSettings.SenderEmail))
            throw new InvalidOperationException("Sender email is not configured.");
    }

    /// <summary>
    ///     Builds the email body based on template, HTML, or plain text content.
    /// </summary>
    /// <param name="notification">The notification containing content information.</param>
    /// <param name="isBodyHtml">Outputs whether the body is HTML.</param>
    /// <returns>The resolved email body string.</returns>
    /// <exception cref="FileNotFoundException">If the template file does not exist.</exception>
    private string BuildEmailBody(Notification notification, out bool isBodyHtml)
    {
        isBodyHtml = false;

        if (notification.NotificationTemplate is not null)
        {
            isBodyHtml = true;
            var templatePath = Path.Combine(AppContext.BaseDirectory, "EmailTemplates", "WelcomeTemplate.html");

            if (!File.Exists(templatePath))
                throw new FileNotFoundException($"Email template not found: {templatePath}");

            var htmlTemplate = File.ReadAllText(templatePath);

            return notification.Metadata != null
                ? ReplaceTemplateVariables(htmlTemplate, notification.Metadata)
                : htmlTemplate;
        }

        if (!string.IsNullOrWhiteSpace(notification.HtmlBody))
        {
            isBodyHtml = true;
            return notification.HtmlBody;
        }

        return notification.Message!;
    }

    /// <summary>
    ///     Creates a configured <see cref="SmtpClient" /> instance for sending emails.
    /// </summary>
    /// <returns>A configured <see cref="SmtpClient" />.</returns>
    private SmtpClient CreateSmtpClient()
    {
        return new SmtpClient(_emailSettings.SmtpHost, _emailSettings.SmtpPort)
        {
            Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.Password),
            EnableSsl = true
        };
    }

    /// <summary>
    ///     Creates a <see cref="MailMessage" /> from the notification data and body content.
    /// </summary>
    /// <param name="notification">The notification data.</param>
    /// <param name="body">The resolved email body.</param>
    /// <param name="isBodyHtml">Whether the email body is HTML.</param>
    /// <returns>A configured <see cref="MailMessage" /> instance.</returns>
    private MailMessage CreateMailMessage(Notification notification, string body, bool isBodyHtml)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
            Subject = notification.Title,
            Body = body,
            IsBodyHtml = isBodyHtml
        };

        mailMessage.To.Add(notification.EmailRecipient!);
        return mailMessage;
    }

    /// <summary>
    ///     Replaces template placeholders in the HTML with metadata values from JSON.
    /// </summary>
    /// <param name="htmlTemplate">The HTML template containing placeholders (e.g., {{Name}}).</param>
    /// <param name="jsonMetadata">The metadata JSON string containing key-value pairs for replacement.</param>
    /// <returns>The updated HTML string with replaced values.</returns>
    public string ReplaceTemplateVariables(string htmlTemplate, string jsonMetadata)
    {
        var metadata = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonMetadata);
        if (metadata == null) return htmlTemplate;

        foreach (var kv in metadata)
        {
            var placeholder = $"{{{{{kv.Key}}}}}"; // Matches format {{Key}}
            htmlTemplate = htmlTemplate.Replace(placeholder, kv.Value);
        }

        return htmlTemplate;
    }

    #endregion
}