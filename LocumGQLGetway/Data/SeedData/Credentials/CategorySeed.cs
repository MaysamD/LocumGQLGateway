using LocumGQLGateway.Models.Credentials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData;

public class CategorySeed : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category
            {
                Id = 1,
                Name = "Personal Information",
                Slug = "personal-information",
                Description = "Basic personal details and identification info",
                SortOrder = 1
            },
            new Category
            {
                Id = 2,
                Name = "Education & Training",
                Slug = "education-training",
                Description = "Information about your education background and training",
                SortOrder = 2
            },
            new Category
            {
                Id = 3,
                Name = "Licenses & Certifications",
                Slug = "licenses-certifications",
                Description = "All professional licenses and certifications",
                SortOrder = 3
            },
            new Category
            {
                Id = 4,
                Name = "Practice & Affiliation",
                Slug = "practice-affiliation",
                Description = "Details about your practice locations and affiliations",
                SortOrder = 4
            },
            new Category
            {
                Id = 5,
                Name = "Work History & References",
                Slug = "work-history-references",
                Description = "Previous work history and professional references",
                SortOrder = 5
            },
            new Category
            {
                Id = 6,
                Name = "Claims & Disclosures",
                Slug = "claims-disclosures",
                Description = "Claims history and disclosures",
                SortOrder = 6
            },
            new Category
            {
                Id = 7,
                Name = "Health & Legal History",
                Slug = "health-legal-history",
                Description = "Health and legal background information",
                SortOrder = 7
            }
        );
    }
}