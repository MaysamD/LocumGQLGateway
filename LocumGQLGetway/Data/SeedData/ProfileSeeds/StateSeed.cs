using LocumGQLGateway.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.ProfileSeeds;

public class StateSeed : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.HasData(
            new State { Id = 1, Name = "Alabama", Abbreviation = "AL" },
            new State { Id = 2, Name = "Alaska", Abbreviation = "AK" },
            new State { Id = 3, Name = "Arizona", Abbreviation = "AZ" },
            new State { Id = 4, Name = "Arkansas", Abbreviation = "AR" },
            new State { Id = 5, Name = "California", Abbreviation = "CA" }
        );
    }
}