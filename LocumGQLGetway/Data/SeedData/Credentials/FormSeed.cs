using LocumGQLGateway.Models.Credentials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.Credentials;

public class FormSeed : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        // ✅ 1. Seed the Form entity here, outside the join table configuration.
        builder.HasData(
            new Form
            {
                Id = 1,
                Name = "Standard Credentialing Form",
                Slug = "physician-credentialing",
                Description =
                    "Collects physician personal details, credentials, and licenses for credentialing purposes.",
                IsActive = true
            }
        );

        // ✅ 2. Configure the many-to-many relationship using a shadow join table.
        // The HasData for the join table is added here.
        builder
            .HasMany(f => f.Categories)
            .WithMany(c => c.Forms) // add a back-navigation in Category
            .UsingEntity<Dictionary<string, object>>( // shadow join table
                "form_category", // table name
                j => j.HasOne<Category>().WithMany().HasForeignKey("category_id"),
                j => j.HasOne<Form>().WithMany().HasForeignKey("form_id"),
                j =>
                {
                    j.HasKey("form_id", "category_id"); // composite PK
                    j.ToTable("form_category"); // table name
                    j.HasData(
                        new { form_id = 1, category_id = 1 },
                        new { form_id = 1, category_id = 2 },
                        new { form_id = 1, category_id = 3 },
                        new { form_id = 1, category_id = 4 },
                        new { form_id = 1, category_id = 5 }
                    );
                });
    }
}