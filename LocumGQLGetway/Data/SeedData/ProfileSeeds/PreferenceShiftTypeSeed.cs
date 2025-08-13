using LocumGQLGateway.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.ProfileSeeds;

public class PreferenceShiftTypeSeed : IEntityTypeConfiguration<PreferenceShiftType>
{
    public void Configure(EntityTypeBuilder<PreferenceShiftType> builder)
    {
        builder.ToTable("PreferenceShiftType");
        
        builder.HasKey(x => new { x.PreferenceId, x.ShiftTypeId });
        builder.HasData(
            new { PreferenceId = 2, ShiftTypeId = 1 },
            new { PreferenceId = 2, ShiftTypeId = 2 }
        );
    }
}