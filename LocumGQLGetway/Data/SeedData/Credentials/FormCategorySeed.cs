using LocumGQLGateway.Models.Credentials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData;

public class FormCategorySeed : IEntityTypeConfiguration<FormCategory>
{
    public void Configure(EntityTypeBuilder<FormCategory> builder)
    {
        builder.HasData(
            new FormCategory
            {
                Id = 1,
                FormId = 1,       // "Physician Credentialing Form"
                CategoryId = 1,   // "Personal Information"
                IncludeAllQuestions = true,
                SortOrder = 1
            },
            new FormCategory
            {
                Id = 2,
                FormId = 1,
                CategoryId = 2,   // "Professional Credentials"
                IncludeAllQuestions = true,
                SortOrder = 2
            },
            new FormCategory
            {
                Id = 3,
                FormId = 1,
                CategoryId = 3,   // "Licenses & Certifications"
                IncludeAllQuestions = true,
                SortOrder = 3
            },
            new FormCategory
            {
                Id = 4,
                FormId = 1,
                CategoryId = 4,   // "Work Experience"
                IncludeAllQuestions = true,
                SortOrder = 4
            },
            new FormCategory
            {
                Id = 5,
                FormId = 1,
                CategoryId = 5,   // "References"
                IncludeAllQuestions = true,
                SortOrder = 5
            }
        );
    }
}