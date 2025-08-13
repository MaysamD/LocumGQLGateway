
using LocumGQLGateway.Models.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.ProfileSeeds;


public class ProfileSeed : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.HasData(
            new Profile
            {
                Id = 1,
                UserId = 1, 
                FirstName = "SuperAdmin",
                LastName = "SuperAdmin",
                PhoneNumber = "(555) 555-5555"
            },
            new Profile
            {
                Id = 2,
                UserId = 2, 
                FirstName = "Admin",
                LastName = "Admin",
                PhoneNumber = "(555) 555-5555"
            },
            new Profile
            {
                Id = 3,
                UserId = 3,
                FirstName = "Locum",
                LastName = "Locum",
                PhoneNumber = "(999) 999-9999"
            }
        );
    }
}