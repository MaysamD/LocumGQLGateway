using LocumApp.Domain.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.ProfileSeeds;

public class ProfileNotificationSettingsSeed : IEntityTypeConfiguration<ProfileNotificationSettings>
{
    public void Configure(EntityTypeBuilder<ProfileNotificationSettings> builder)
    {
        builder.HasData(
            new ProfileNotificationSettings
            {
                Id = 1,
                ProfileId = 1,
                CertificateExpirationInApp = true,
                CertificateExpirationEmail = true,
                CertificateExpirationSms = false,
                JobMatchNotificationsInApp = true,
                JobMatchNotificationsEmail = false,
                JobMatchNotificationsSms = false,
                CredentialingUpdatesInApp = false,
                CredentialingUpdatesEmail = false,
                CredentialingUpdatesSms = false,
                GeneralRemindersInApp = false,
                GeneralRemindersEmail = false,
                GeneralRemindersSms = true
            },
            new ProfileNotificationSettings
            {
                Id = 2,
                ProfileId = 2,
                CertificateExpirationInApp = false,
                CertificateExpirationEmail = false,
                CertificateExpirationSms = false,
                JobMatchNotificationsInApp = false,
                JobMatchNotificationsEmail = false,
                JobMatchNotificationsSms = false,
                CredentialingUpdatesInApp = false,
                CredentialingUpdatesEmail = false,
                CredentialingUpdatesSms = false,
                GeneralRemindersInApp = false,
                GeneralRemindersEmail = false,
                GeneralRemindersSms = false
            }
        );
    }
}