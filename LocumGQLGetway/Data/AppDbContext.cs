using LocumGQLGateway.Data.SeedData;
using LocumGQLGateway.Data.SeedData.ProfileSeeds;
using LocumGQLGateway.Enums;
using LocumGQLGateway.Models;
using LocumGQLGateway.Models.Credentials;
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
    
    // Credentials
  //  public DbSet<Form> Form => Set<Form>();
  //  public DbSet<Category> Category => Set<Category>();

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
        modelBuilder.ApplyConfiguration(new PreferenceFacilityTypeSeed());
        modelBuilder.ApplyConfiguration(new PreferenceJobTypeSeed());
        modelBuilder.ApplyConfiguration(new PreferenceShiftTypeSeed());
        modelBuilder.ApplyConfiguration(new PreferenceLocationTypeSeed());
        modelBuilder.ApplyConfiguration(new PreferenceStateSeed());
        modelBuilder.ApplyConfiguration(new ProfileNotificationSettingsSeed());
 
        //modelBuilder.ApplyConfiguration(new CategorySeed());
        //modelBuilder.ApplyConfiguration(new FormSeed());
        //modelBuilder.ApplyConfiguration(new FormCategorySeed());
    }
}