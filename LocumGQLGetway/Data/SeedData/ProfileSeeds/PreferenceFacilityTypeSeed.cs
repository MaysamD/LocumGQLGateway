using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.ProfileSeeds;

public class PreferenceFacilityTypeSeed : IEntityTypeConfiguration<PreferenceFacilityType>
{
   
    public void Configure(EntityTypeBuilder<PreferenceFacilityType> builder)
    { 
        builder.ToTable("PreferenceFacilityType");
        builder.HasKey(x => new { x.PreferenceId, x.FacilityTypeId });
        builder.HasData(
            new { PreferenceId = 2, FacilityTypeId = 1 },
            new { PreferenceId = 2, FacilityTypeId = 2 }
        );
    }
}