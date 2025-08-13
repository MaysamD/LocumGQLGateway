using Microsoft.EntityFrameworkCore;

namespace LocumGQLGateway.Extensions;

public static class ModelBuilderExtensions
{
    public static void ConfigureManyToManyJoinTable<TLeft, TRight>(
        this ModelBuilder modelBuilder, string? tableName = "")
        where TLeft : class
        where TRight : class
    {
        var leftName = typeof(TLeft).Name;  
        var rightName = typeof(TRight).Name;

        if (string.IsNullOrEmpty(tableName)) tableName = $"{leftName}_{rightName}";
        var leftKey = $"{leftName}Id";
        var rightKey = $"{rightName}Id";

        modelBuilder.Entity<TLeft>()
            .HasMany<TRight>()
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                tableName,
                l => l.HasOne<TRight>().WithMany().HasForeignKey(rightKey),
                r => r.HasOne<TLeft>().WithMany().HasForeignKey(leftKey),
                j =>
                {
                    j.HasKey(leftKey, rightKey);
                    j.ToTable(tableName);
                });
    }
}