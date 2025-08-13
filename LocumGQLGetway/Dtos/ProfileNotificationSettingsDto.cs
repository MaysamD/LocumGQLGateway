namespace LocumGQLGateway.Dtos;

public class ProfileNotificationSettingsDto
{
    // Certificate Expiration
    public bool CertificateExpirationInApp { get; set; }
    public bool CertificateExpirationEmail { get; set; }
    public bool CertificateExpirationSms { get; set; }

    // Job Match Notifications
    public bool JobMatchNotificationsInApp { get; set; }
    public bool JobMatchNotificationsEmail { get; set; }
    public bool JobMatchNotificationsSms { get; set; }

    // Credentialing Updates
    public bool CredentialingUpdatesInApp { get; set; }
    public bool CredentialingUpdatesEmail { get; set; }
    public bool CredentialingUpdatesSms { get; set; }

    // General Reminders
    public bool GeneralRemindersInApp { get; set; }
    public bool GeneralRemindersEmail { get; set; }
    public bool GeneralRemindersSms { get; set; }
}