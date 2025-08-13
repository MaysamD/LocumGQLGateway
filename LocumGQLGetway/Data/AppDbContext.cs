using LocumGQLGateway.Enums;
using LocumGQLGateway.Models;
using LocumGQLGateway.Models.Profiles;
using Microsoft.EntityFrameworkCore;

namespace LocumGQLGateway.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<Preference> Preferences => Set<Preference>();
    public DbSet<FacilityType> FacilityTypes => Set<FacilityType>();
    public DbSet<ShiftType> ShiftTypes => Set<ShiftType>();
    public DbSet<JobType> JobTypes => Set<JobType>();
    public DbSet<LocationType> LocationTypes => Set<LocationType>();
    public DbSet<State> States => Set<State>();
    public DbSet<Address> Address => Set<Address>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User-Profile one-to-one
        modelBuilder.Entity<User>()
            .HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<Profile>(p => p.UserId);

        // Profile-Preference one-to-one
        modelBuilder.Entity<Profile>()
            .HasOne(p => p.Preference)
            .WithOne(pref => pref.Profile)
            .HasForeignKey<Preference>(pref => pref.ProfileId);

        // Profile-Address one-to-one
        modelBuilder.Entity<Profile>()
            .HasOne(p => p.Address)
            .WithOne(pref => pref.Profile)
            .HasForeignKey<Address>(pref => pref.ProfileId);

        // Profile - ProfileNotificationSettings one-to-one
        modelBuilder.Entity<Profile>()
            .HasOne(p => p.ProfileNotificationSettings)
            .WithOne(pns => pns.Profile)
            .HasForeignKey<ProfileNotificationSettings>(pns => pns.ProfileId);

        // Preference-FacilityType many-to-many
        modelBuilder.Entity<Preference>()
            .HasMany(p => p.FacilityTypes)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "PreferenceFacilityType",
                j => j.HasOne<FacilityType>().WithMany().HasForeignKey("FacilityTypeId"),
                j => j.HasOne<Preference>().WithMany().HasForeignKey("PreferenceId"),
                j =>
                {
                    j.HasKey("PreferenceId", "FacilityTypeId"); // 👈 Composite PK
                }
            );

        // Preference-JobTypes many-to-many
        modelBuilder.Entity<Preference>()
            .HasMany(p => p.JobTypes)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "PreferenceJobType",
                j => j.HasOne<JobType>().WithMany().HasForeignKey("JobTypeId"),
                j => j.HasOne<Preference>().WithMany().HasForeignKey("PreferenceId"),
                j =>
                {
                    j.HasKey("PreferenceId", "JobTypeId"); // 👈 Composite PK
                }
            );

        // Preference-ShiftTypes many-to-many
        modelBuilder.Entity<Preference>()
            .HasMany(p => p.ShiftTypes)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "PreferenceShiftType",
                j => j.HasOne<ShiftType>().WithMany().HasForeignKey("ShiftTypeId"),
                j => j.HasOne<Preference>().WithMany().HasForeignKey("PreferenceId"),
                j =>
                {
                    j.HasKey("PreferenceId", "ShiftTypeId"); // 👈 Composite PK
                }
            );

        // Preference-LocationTypes many-to-many
        modelBuilder.Entity<Preference>()
            .HasMany(p => p.LocationTypes)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "PreferenceLocationType",
                j => j.HasOne<LocationType>().WithMany().HasForeignKey("LocationTypeId"),
                j => j.HasOne<Preference>().WithMany().HasForeignKey("PreferenceId"),
                j =>
                {
                    j.HasKey("PreferenceId", "LocationTypeId"); // Composite PK
                }
            );

        // Preference-States many-to-many
        modelBuilder.Entity<Preference>()
            .HasMany(p => p.States)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "PreferenceState",
                j => j.HasOne<State>().WithMany().HasForeignKey("StateId"),
                j => j.HasOne<Preference>().WithMany().HasForeignKey("PreferenceId"),
                j =>
                {
                    j.HasKey("PreferenceId", "StateId"); // Composite PK
                }
            );
        // Seed everything else
        SeedData(modelBuilder);
    }


    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FacilityType>().HasData(
            new FacilityType { Id = 1, Name = "Hospital" },
            new FacilityType { Id = 2, Name = "Clinic" },
            new FacilityType { Id = 3, Name = "Urgent Care" },
            new FacilityType { Id = 4, Name = "Rehabilitation Center" }
        );

        modelBuilder.Entity<JobType>().HasData(
            new JobType { Id = 1, Name = "Full-Time" },
            new JobType { Id = 2, Name = "Part-Time" },
            new JobType { Id = 3, Name = "Contract" },
            new JobType { Id = 4, Name = "Temporary" },
            new JobType { Id = 5, Name = "Internship" }
        );

        modelBuilder.Entity<ShiftType>().HasData(
            new ShiftType { Id = 1, Name = "Morning" },
            new ShiftType { Id = 2, Name = "Afternoon" },
            new ShiftType { Id = 3, Name = "Evening" },
            new ShiftType { Id = 4, Name = "Night" },
            new ShiftType { Id = 5, Name = "On-Call" }
        );
        // ===== Seed Users =====
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "SuperAdmin",
                Email = "SuperAdmin@example.com",
                PasswordHash = "TBD", // Or pre-hashed
                Role = Role.SuperAdmin
            },  new User
            {
                Id = 2,
                Username = "admin",
                Email = "admin@example.com",
                PasswordHash = "TBD", // Or pre-hashed
                Role = Role.Admin
            },
            new User
            {
                Id = 3,
                Username = "Locum",
                Email = "Locum@example.com",
                PasswordHash = "TBD", // Or pre-hashed
                Role = Role.Locum
            }
        );
// Seed LocationType
        modelBuilder.Entity<LocationType>().HasData(
            new LocationType { Id = 1, Name = "Urban" },
            new LocationType { Id = 2, Name = "Suburban" },
            new LocationType { Id = 3, Name = "Rural" },
            new LocationType { Id = 4, Name = "Remote" }
        );

// Seed State
        modelBuilder.Entity<State>().HasData(
            new State { Id = 1, Name = "Alabama", Abbreviation = "AL" },
            new State { Id = 2, Name = "Alaska", Abbreviation = "AK" },
            new State { Id = 3, Name = "Arizona", Abbreviation = "AZ" },
            new State { Id = 4, Name = "Arkansas", Abbreviation = "AR" },
            new State
            {
                Id = 5, Name = "California", Abbreviation = "CA"
            }
            // Add more states as needed
        );
        // ===== Seed Profiles =====
        modelBuilder.Entity<Profile>().HasData(
            new Profile
            {
                Id = 1,
                UserId = 1, 
                FirstName = "SuperAdmin",
                LastName = "SuperAdmin",
                PhoneNumber = "(555) 555-5555"
            },
            new Profile
            {
                Id = 2,
                UserId = 2, 
                FirstName = "Admin",
                LastName = "Admin",
                PhoneNumber = "(555) 555-5555"
            },
            new Profile
            {
                Id = 3,
                UserId = 3,
                FirstName = "Locum",
                LastName = "Locum",
                PhoneNumber = "(999) 999-9999"
            }
        );


// ===== Seed Preferences =====
        modelBuilder.Entity<Preference>().HasData(
            new Preference
            {
                Id = 1,
                ProfileId = 1 
            },
            new Preference
            {
                Id = 2,
                ProfileId = 2 
            }
        );

// ===== Seed Join Table (Preference ↔ FacilityType) =====
        modelBuilder.Entity("PreferenceFacilityType").HasData(
            new { PreferenceId = 2, FacilityTypeId = 1 },
            new { PreferenceId = 2, FacilityTypeId = 2 }
        );

        // ===== Seed Join Table (Preference ↔ FacilityType) =====
        modelBuilder.Entity("PreferenceJobType").HasData(
            new { PreferenceId = 2, JobTypeId = 1 },
            new { PreferenceId = 2, JobTypeId = 2 }
        );
        // ===== Seed Join Table (Preference ↔ ShiftType) =====
        modelBuilder.Entity("PreferenceShiftType").HasData(
            new { PreferenceId = 2, ShiftTypeId = 1 },
            new { PreferenceId = 2, ShiftTypeId = 2 }
        );

        // ===== Seed Join Table (Preference ↔ LocationType) =====
        modelBuilder.Entity("PreferenceLocationType").HasData(
            new { PreferenceId = 2, LocationTypeId = 1 },
            new { PreferenceId = 2, LocationTypeId = 3 }
        );

        // ===== Seed Join Table (Preference ↔ State) =====
        modelBuilder.Entity("PreferenceState").HasData(
            new { PreferenceId = 2, StateId = 1 },
            new { PreferenceId = 2, StateId = 5 }
        );

        // ===== Seed ProfileNotificationSettings =====
        modelBuilder.Entity<ProfileNotificationSettings>().HasData(
            new ProfileNotificationSettings
            {
                Id = 1,
                ProfileId = 1,

                // Certificate Expiration
                CertificateExpirationInApp = true,
                CertificateExpirationEmail = true,
                CertificateExpirationSms = false,

                // Job Match Notifications
                JobMatchNotificationsInApp = true,
                JobMatchNotificationsEmail = false,
                JobMatchNotificationsSms = false,

                // Credentialing Updates
                CredentialingUpdatesInApp = false,
                CredentialingUpdatesEmail = false,
                CredentialingUpdatesSms = false,

                // General Reminders
                GeneralRemindersInApp = false,
                GeneralRemindersEmail = false,
                GeneralRemindersSms = true
            },
            new ProfileNotificationSettings
            {
                Id = 2,
                ProfileId = 2,

                // Certificate Expiration
                CertificateExpirationInApp = false,
                CertificateExpirationEmail = false,
                CertificateExpirationSms = false,

                // Job Match Notifications
                JobMatchNotificationsInApp = false,
                JobMatchNotificationsEmail = false,
                JobMatchNotificationsSms = false,

                // Credentialing Updates
                CredentialingUpdatesInApp = false,
                CredentialingUpdatesEmail = false,
                CredentialingUpdatesSms = false,

                // General Reminders
                GeneralRemindersInApp = false,
                GeneralRemindersEmail = false,
                GeneralRemindersSms = false
            }
        );
    }
}