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
    }
}