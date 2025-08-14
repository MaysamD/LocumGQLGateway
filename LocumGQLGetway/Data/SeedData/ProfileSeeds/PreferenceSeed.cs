using LocumGQLGateway.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.ProfileSeeds;

public class PreferenceSeed : IEntityTypeConfiguration<Preference>
{
    public void Configure(EntityTypeBuilder<Preference> builder)
    {
        builder.HasData(
            new Preference { Id = 1, ProfileId = 1 },
            new Preference { Id = 2, ProfileId = 2 }
        );

        // Preference-FacilityType many-to-many
        builder
            .HasMany(p => p.FacilityTypes)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "preference_facility_type",
                j => j.HasOne<FacilityType>().WithMany().HasForeignKey("facility_type_id"),
                j => j.HasOne<Preference>().WithMany().HasForeignKey("preference_id"),
                j =>
                {
                    j.HasKey("facility_type_id", "preference_id"); // composite PK
                    j.ToTable("preference_facility_type"); // table name
                    j.HasData(
                        new { preference_id = 1, facility_type_id = 1 },
                        new { preference_id = 1, facility_type_id = 2 }
                    );
                });


        // Preference-JobType many-to-many
        builder
            .HasMany(p => p.JobTypes)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "preference_job_type",
                j => j.HasOne<JobType>().WithMany().HasForeignKey("job_type_id"),
                j => j.HasOne<Preference>().WithMany().HasForeignKey("preference_id"),
                j =>
                {
                    j.HasKey("job_type_id", "preference_id"); // composite PK
                    j.ToTable("preference_job_type"); // table name
                    j.HasData(
                        new { preference_id = 1, job_type_id = 1 },
                        new { preference_id = 1, job_type_id = 2 }
                    );
                });

        // Preference-ShiftType many-to-many
        builder
            .HasMany(p => p.ShiftTypes)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "preference_shift_type",
                j => j.HasOne<ShiftType>().WithMany().HasForeignKey("shift_type_id"),
                j => j.HasOne<Preference>().WithMany().HasForeignKey("preference_id"),
                j =>
                {
                    j.HasKey("shift_type_id", "preference_id"); // composite PK
                    j.ToTable("preference_shift_type"); // table name
                    j.HasData(
                        new { preference_id = 1, shift_type_id = 1 },
                        new { preference_id = 1, shift_type_id = 2 }
                    );
                });

// Preference-State many-to-many
        builder
            .HasMany(p => p.States)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "preference_state",
                j => j.HasOne<State>().WithMany().HasForeignKey("state_id"),
                j => j.HasOne<Preference>().WithMany().HasForeignKey("preference_id"),
                j =>
                {
                    j.HasKey("state_id", "preference_id"); // composite PK
                    j.ToTable("preference_state"); // table name
                    j.HasData(
                        new { preference_id = 1, state_id = 1 },
                        new { preference_id = 1, state_id = 2 }
                    );
                });

// Preference-LocationType many-to-many
        builder
            .HasMany(p => p.LocationTypes)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "preference_location_type",
                j => j.HasOne<LocationType>().WithMany().HasForeignKey("location_type_id"),
                j => j.HasOne<Preference>().WithMany().HasForeignKey("preference_id"),
                j =>
                {
                    j.HasKey("location_type_id", "preference_id"); // composite PK
                    j.ToTable("preference_location_type"); // table name
                    j.HasData(
                        new { preference_id = 1, location_type_id = 1 },
                        new { preference_id = 1, location_type_id = 2 }
                    );
                });
    }
}