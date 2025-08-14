using LocumApp.Domain.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.ProfileSeeds;

public class LocationTypeSeed : IEntityTypeConfiguration<LocationType>
{
    public void Configure(EntityTypeBuilder<LocationType> builder)
    {
        builder.HasData(
            new LocationType { Id = 1, Name = "Urban" },
            new LocationType { Id = 2, Name = "Suburban" },
            new LocationType { Id = 3, Name = "Rural" },
            new LocationType { Id = 4, Name = "Remote" }
        );
    }
}