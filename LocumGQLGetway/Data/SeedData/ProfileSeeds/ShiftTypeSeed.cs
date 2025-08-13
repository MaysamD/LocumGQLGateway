using LocumGQLGateway.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.ProfileSeeds;

public class ShiftTypeSeed : IEntityTypeConfiguration<ShiftType>
{
    public void Configure(EntityTypeBuilder<ShiftType> builder)
    {
        builder.HasData(
            new ShiftType { Id = 1, Name = "Morning" },
            new ShiftType { Id = 2, Name = "Afternoon" },
            new ShiftType { Id = 3, Name = "Evening" },
            new ShiftType { Id = 4, Name = "Night" },
            new ShiftType { Id = 5, Name = "On-Call" }
        );
    }
}