using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocumApp.Domain.Enums;

namespace LocumApp.Domain.Models.Notifications;

[Table("notifications")]
public class Notification : BaseEntity
{
    private string? _htmlBody;
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

#pragma warning disable CS0108, CS0114
    public Guid Id { get; set; }
#pragma warning restore CS0108, CS0114

    /// <summary>
    ///     Type of notification (InApp, SMS, Email).
    /// </summary>
    [Required]
    [Column("type")]
    public NotificationType Type { get; set; }

    /// <summary>
    ///     Email recipient address (required if Type = Email).
    /// </summary>
    [MaxLength(255)]
    [EmailAddress]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address format.")]
    [Column("email_recipient")]
    public string? EmailRecipient { get; set; }

    /// <summary>
    ///     SMS recipient phone number (required if Type = SMS).
    ///     E.164 format: +[country code][number], e.g. +14155552671
    /// </summary>
    [MaxLength(20)]
    [RegularExpression(@"^\+[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format. Use E.164 format.")]
    [Column("sms_recipient")]
    public string? SmsRecipient { get; set; }

    /// <summary>
    ///     In-app recipient user ID (required if Type = InApp).
    /// </summary>
    [Column("user_id_recipient")]
    [Required]
    public int UserId { get; set; }

    /// <summary>
    ///     The title or subject for the notification (used for Email and InApp).
    /// </summary>
    [MaxLength(255)]
    [Column("title")]
    public string? Title { get; set; }

    /// <summary>
    ///     Main message body for the notification.
    /// </summary>
    [Required]
    [Column("message")]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    ///     Optional HTML body for Email notifications.
    /// </summary>
    [Column("html_body", TypeName = "text")]
    public string? HtmlBody
    {
        get => _htmlBody;
        set => _htmlBody = value?.SanitizeHtml() ?? string.Empty;
    }

    /// <summary>
    ///     The current status of the notification.
    /// </summary>
    [Required]
    [Column("status")]
    public NotificationStatus Status { get; set; } = NotificationStatus.Pending;

    /// <summary>
    ///     Optional metadata or tags (e.g., JSON for dynamic data).
    /// </summary>
    [Column("metadata", TypeName = "text")]
    public string? Metadata { get; set; }

    /// <summary>
    ///     Optional metadata or tags (e.g., JSON for dynamic data).
    /// </summary>
    /// <summary>
    ///     Gets or sets the <see cref="NotificationTemplate" /> associated with this notification.
    /// </summary>
    /// <remarks>
    ///     This property can be <c>null</c> if no template is assigned.
    ///     The <see cref="NotificationTemplate" /> contains the HTML content, metadata placeholders,
    ///     and other template-specific settings used when sending notifications.
    /// </remarks>
    [Column("notification_template")]
    public NotificationTemplate? NotificationTemplate { get; set; }
}