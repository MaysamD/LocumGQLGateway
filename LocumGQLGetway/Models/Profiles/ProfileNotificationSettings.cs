using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Models.Profiles
{
    /// <summary>
    /// Represents notification preferences for a profile across different notification types and channels.
    /// </summary>
    public class ProfileNotificationSettings : BaseEntity
    {
        /// <summary>
        /// Foreign key referencing the associated profile.
        /// </summary>
        [Required]
        public int ProfileId { get; set; }

        /// <summary>
        /// Navigation property to the associated profile.
        /// </summary>
        public Profile? Profile { get; set; }

        #region Certificate Expiration Notifications

        /// <summary>
        /// Receive certificate expiration notifications via in-app messages.
        /// </summary>
        public bool CertificateExpirationInApp { get; set; } = true;

        /// <summary>
        /// Receive certificate expiration notifications via email.
        /// </summary>
        public bool CertificateExpirationEmail { get; set; } = false;

        /// <summary>
        /// Receive certificate expiration notifications via SMS.
        /// </summary>
        public bool CertificateExpirationSms { get; set; } = false;

        #endregion

        #region Job Match Notifications

        /// <summary>
        /// Receive job match notifications via in-app messages.
        /// </summary>
        public bool JobMatchNotificationsInApp { get; set; } = true;

        /// <summary>
        /// Receive job match notifications via email.
        /// </summary>
        public bool JobMatchNotificationsEmail { get; set; } = false;

        /// <summary>
        /// Receive job match notifications via SMS.
        /// </summary>
        public bool JobMatchNotificationsSms { get; set; } = false;

        #endregion

        #region Credentialing Updates Notifications

        /// <summary>
        /// Receive credentialing update notifications via in-app messages.
        /// </summary>
        public bool CredentialingUpdatesInApp { get; set; } = true;

        /// <summary>
        /// Receive credentialing update notifications via email.
        /// </summary>
        public bool CredentialingUpdatesEmail { get; set; } = false;

        /// <summary>
        /// Receive credentialing update notifications via SMS.
        /// </summary>
        public bool CredentialingUpdatesSms { get; set; } = false;

        #endregion

        #region General Reminders

        /// <summary>
        /// Receive general reminder notifications via in-app messages.
        /// </summary>
        public bool GeneralRemindersInApp { get; set; } = true;

        /// <summary>
        /// Receive general reminder notifications via email.
        /// </summary>
        public bool GeneralRemindersEmail { get; set; } = false;

        /// <summary>
        /// Receive general reminder notifications via SMS.
        /// </summary>
        public bool GeneralRemindersSms { get; set; } = false;

        #endregion
    }
}
