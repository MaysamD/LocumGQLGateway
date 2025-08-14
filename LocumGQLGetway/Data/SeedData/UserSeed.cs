using LocumApp.Domain.Enums;
using LocumApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData;

public class UserSeed : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                Id = 1,
                Username = "SuperAdmin",
                Email = "SuperAdmin@example.com",
                PasswordHash = "TBD", // Pre-hash in production
                Role = Role.SuperAdmin
            },
            new User
            {
                Id = 2,
                Username = "admin",
                Email = "admin@example.com",
                PasswordHash = "TBD",
                Role = Role.Admin
            },
            new User
            {
                Id = 3,
                Username = "Locum",
                Email = "Locum@example.com",
                PasswordHash = "TBD",
                Role = Role.Locum
            }
        );
    }
}