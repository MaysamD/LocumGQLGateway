using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocumApp.Domain.Enums;

namespace LocumApp.Domain.Models.Notifications;

[Table("notifications")]
public class Notification : BaseEntity
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public Guid Id { get; set; }

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
    public string? HtmlBody { get; set; }

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
}