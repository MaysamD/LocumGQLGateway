using LocumGQLGateway.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.ProfileSeeds;

public class PreferenceJobTypeSeed : IEntityTypeConfiguration<PreferenceJobType>
{
    public void Configure(EntityTypeBuilder<PreferenceJobType> builder)
    {
        builder.ToTable("PreferenceJobType");
        builder.HasKey(x => new { x.PreferenceId, x.JobTypeId });
        builder.HasData(
            new { PreferenceId = 2, JobTypeId = 1 },
            new { PreferenceId = 2, JobTypeId = 2 }
        );
    }
}

       