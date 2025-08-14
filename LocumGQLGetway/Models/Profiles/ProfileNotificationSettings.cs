using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Added for Table/Column attributes

namespace LocumGQLGateway.Models.Profiles;

/// <summary>
///     Represents notification preferences for a profile across different notification types and channels.
/// </summary>
[Table("profile_notification_settings")] // Added Table attribute
public class ProfileNotificationSettings : BaseEntity
{
    /// <summary>
    ///     Foreign key referencing the associated profile.
    /// </summary>
    [Required]
    [Column("profile_id")] // Added Column attribute
    public int ProfileId { get; set; }

    /// <summary>
    ///     Navigation property to the associated profile.
    /// </summary>
    public Profile? Profile { get; set; }

    #region Certificate Expiration Notifications

    /// <summary>
    ///     Receive certificate expiration notifications via in-app messages.
    /// </summary>
    [Column("certificate_expiration_in_app")] // Added Column attribute
    public bool CertificateExpirationInApp { get; set; } = true;

    /// <summary>
    ///     Receive certificate expiration notifications via email.
    /// </summary>
    [Column("certificate_expiration_email")] // Added Column attribute
    public bool CertificateExpirationEmail { get; set; } = false;

    /// <summary>
    ///     Receive certificate expiration notifications via SMS.
    /// </summary>
    [Column("certificate_expiration_sms")] // Added Column attribute
    public bool CertificateExpirationSms { get; set; } = false;

    #endregion

    #region Job Match Notifications

    /// <summary>
    ///     Receive job match notifications via in-app messages.
    /// </summary>
    [Column("job_match_notifications_in_app")] // Added Column attribute
    public bool JobMatchNotificationsInApp { get; set; } = true;

    /// <summary>
    ///     Receive job match notifications via email.
    /// </summary>
    [Column("job_match_notifications_email")] // Added Column attribute
    public bool JobMatchNotificationsEmail { get; set; } = false;

    /// <summary>
    ///     Receive job match notifications via SMS.
    /// </summary>
    [Column("job_match_notifications_sms")] // Added Column attribute
    public bool JobMatchNotificationsSms { get; set; } = false;

    #endregion

    #region Credentialing Updates Notifications

    /// <summary>
    ///     Receive credentialing update notifications via in-app messages.
    /// </summary>
    [Column("credentialing_updates_in_app")] // Added Column attribute
    public bool CredentialingUpdatesInApp { get; set; } = true;

    /// <summary>
    ///     Receive credentialing update notifications via email.
    /// </summary>
    [Column("credentialing_updates_email")] // Added Column attribute
    public bool CredentialingUpdatesEmail { get; set; } = false;

    /// <summary>
    ///     Receive credentialing update notifications via SMS.
    /// </summary>
    [Column("credentialing_updates_sms")] // Added Column attribute
    public bool CredentialingUpdatesSms { get; set; } = false;

    #endregion

    #region General Reminders

    /// <summary>
    ///     Receive general reminder notifications via in-app messages.
    /// </summary>
    [Column("general_reminders_in_app")] // Added Column attribute
    public bool GeneralRemindersInApp { get; set; } = true;

    /// <summary>
    ///     Receive general reminder notifications via email.
    /// </summary>
    [Column("general_reminders_email")] // Added Column attribute
    public bool GeneralRemindersEmail { get; set; } = false;

    /// <summary>
    ///     Receive general reminder notifications via SMS.
    /// </summary>
    [Column("general_reminders_sms")] // Added Column attribute
    public bool GeneralRemindersSms { get; set; } = false;

    #endregion
}