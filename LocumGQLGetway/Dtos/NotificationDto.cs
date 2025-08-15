using System.ComponentModel.DataAnnotations;
using LocumApp.Domain.Enums;

namespace LocumApp.Application.DTOs;

public class NotificationDto
{
    /// <summary>
    ///     Type of notification (InApp, SMS, Email).
    /// </summary>
    [Required]
    public NotificationType Type { get; set; }

    /// <summary>
    ///     Email recipient address (required if Type = Email).
    /// </summary>
    [MaxLength(255)]
    [EmailAddress]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email address format.")]
    public string? EmailRecipient { get; set; }

    /// <summary>
    ///     SMS recipient phone number (required if Type = SMS).
    ///     E.164 format: +[country code][number], e.g. +14155552671
    /// </summary>
    [MaxLength(20)]
    [RegularExpression(@"^\+[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format. Use E.164 format.")]
    public string? SmsRecipient { get; set; }

    /// <summary>
    ///     In-app recipient user ID (required if Type = InApp).
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    ///     The title or subject for the notification (used for Email and InApp).
    /// </summary>
    [MaxLength(255)]
    public string? Title { get; set; }

    /// <summary>
    ///     Main message body for the notification.
    /// </summary>
    [Required]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    ///     Optional HTML body for Email notifications.
    /// </summary>
    public string? HtmlBody { get; set; }

    /// <summary>
    ///     The current status of the notification.
    /// </summary>
    public NotificationStatus? Status { get; set; } = NotificationStatus.Pending;

    /// <summary>
    ///     Optional metadata or tags (e.g., JSON for dynamic data).
    /// </summary>
    public string? Metadata { get; set; }
}