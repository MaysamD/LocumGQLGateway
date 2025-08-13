using LocumGQLGateway.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.ProfileSeeds;

public class PreferenceLocationTypeSeed : IEntityTypeConfiguration<PreferenceLocationType>
{
    public void Configure(EntityTypeBuilder<PreferenceLocationType> builder)
    {
        builder.ToTable("PreferenceLocationType");
        builder.HasKey(x => new { x.PreferenceId, x.LocationTypeId });
        builder.HasData(
            new { PreferenceId = 2, LocationTypeId = 1 },
            new { PreferenceId = 2, LocationTypeId = 3 }
        );
    }
}