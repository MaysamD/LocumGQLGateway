using LocumGQLGateway.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.ProfileSeeds;

public class PreferenceStateSeed : IEntityTypeConfiguration<PreferenceState>
{
    public void Configure(EntityTypeBuilder<PreferenceState> builder)
    {
        builder.ToTable("PreferenceState");
        builder.HasKey(x => new { x.PreferenceId, x.StateId });
        builder.HasData(
            new { PreferenceId = 2, StateId = 1 },
            new { PreferenceId = 2, StateId = 5 }
        );
    }
}