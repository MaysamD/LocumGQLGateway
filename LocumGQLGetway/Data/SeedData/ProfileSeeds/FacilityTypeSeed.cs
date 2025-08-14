using LocumApp.Domain.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.ProfileSeeds;

public class FacilityTypeSeed : IEntityTypeConfiguration<FacilityType>
{
    public void Configure(EntityTypeBuilder<FacilityType> builder)
    {
        builder.HasData(
            new FacilityType { Id = 1, Name = "Hospital" },
            new FacilityType { Id = 2, Name = "Clinic" },
            new FacilityType { Id = 3, Name = "Urgent Care" },
            new FacilityType { Id = 4, Name = "Rehabilitation Center" }
        );
    }
}