using LocumGQLGateway.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.ProfileSeeds;

public class JobTypeSeed : IEntityTypeConfiguration<JobType>
{
    public void Configure(EntityTypeBuilder<JobType> builder)
    {
        builder.HasData(
            new JobType { Id = 1, Name = "Full-Time" },
            new JobType { Id = 2, Name = "Part-Time" },
            new JobType { Id = 3, Name = "Contract" },
            new JobType { Id = 4, Name = "Temporary" },
            new JobType { Id = 5, Name = "Internship" }
        );
    }
}