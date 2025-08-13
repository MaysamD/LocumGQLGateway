using LocumGQLGateway.Models.Credentials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData;


public class FormSeed : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.HasData(
            new Form
            {
                Id = 1,
                Name = "Standard Credentialing Form",
                Slug = "physician-credentialing",
                Description = "Collects physician personal details, credentials, and licenses for credentialing purposes.",
                IsActive = true
            }
        );
    }
}