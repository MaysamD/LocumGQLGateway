using LocumGQLGateway.Models.Credentials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.Credentials;

public class CategoryQuestionSeed : IEntityTypeConfiguration<CategoryQuestion>
{
    public void Configure(EntityTypeBuilder<CategoryQuestion> builder)
    {
        builder.ToTable("category_question");
        builder.HasKey(x => new { x.Id, x.CategoryId, x.QuestionId });
        builder.HasData(
            new { Id = 2, CategoryId = 1, QuestionId = 1 },
            new { Id = 2, CategoryId = 1, QuestionId = 2 }
        );
    }
}