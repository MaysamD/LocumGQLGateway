using LocumGQLGateway.Data.SeedData;
using LocumGQLGateway.Data.SeedData.Credentials;
using LocumGQLGateway.Data.SeedData.ProfileSeeds;
using LocumGQLGateway.Models;
using LocumGQLGateway.Models.Credentials;
using LocumGQLGateway.Models.Profiles;
using Microsoft.EntityFrameworkCore;

namespace LocumGQLGateway.Data;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
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

    // Credentials
    public DbSet<Form> Forms => Set<Form>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<UserCredential> UserCredential => Set<UserCredential>();
    public DbSet<CategoryQuestion> CategoryQuestions => Set<CategoryQuestion>();
    public DbSet<QuestionOption> QuestionOptions => Set<QuestionOption>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Get the connection string from appsettings
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        // Only enable in development to avoid logging sensitive data in production
        if (!optionsBuilder.IsConfigured)
            optionsBuilder
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .EnableSensitiveDataLogging();
    }

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

        // This is the key part to apply the configuration to all models
        // that inherit from BaseEntity.
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                // Configure CreatedAtUtc
                modelBuilder.Entity(entityType.ClrType)
                    .Property("CreatedAtUtc")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                // Configure UpdatedAtUtc
                modelBuilder.Entity(entityType.ClrType)
                    .Property("UpdatedAtUtc")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            }

        // Seed everything else
        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserSeed());

        modelBuilder.ApplyConfiguration(new FacilityTypeSeed());
        modelBuilder.ApplyConfiguration(new JobTypeSeed());
        modelBuilder.ApplyConfiguration(new ShiftTypeSeed());
        modelBuilder.ApplyConfiguration(new LocationTypeSeed());
        modelBuilder.ApplyConfiguration(new StateSeed());

        modelBuilder.ApplyConfiguration(new ProfileSeed());
        modelBuilder.ApplyConfiguration(new PreferenceSeed());
        modelBuilder.ApplyConfiguration(new ProfileNotificationSettingsSeed());

        modelBuilder.ApplyConfiguration(new FormSeed());
        modelBuilder.ApplyConfiguration(new CategorySeed());
        modelBuilder.ApplyConfiguration(new QuestionSeed());
        modelBuilder.ApplyConfiguration(new CategoryQuestionSeed());
    }
}