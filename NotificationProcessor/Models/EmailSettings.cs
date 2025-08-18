namespace NotificationProcessor.Models;

/// <summary>
///     Represents the configuration settings required to send emails via SMTP.
/// </summary>
public class EmailSettings
{
    /// <summary>
    ///     Gets or sets the SMTP server host name (e.g., smtp.gmail.com).
    /// </summary>
    public string SmtpHost { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the SMTP server port (e.g., 587 for TLS/STARTTLS).
    /// </summary>
    public int SmtpPort { get; set; }

    /// <summary>
    ///     Gets or sets the email address that will be used as the sender.
    /// </summary>
    public string SenderEmail { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the display name of the sender.
    /// </summary>
    public string SenderName { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the password or app-specific password for the sender email account.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}