using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Models.Credentials;

/// <summary>
///     Represents a category grouping for questions or credentials.
/// </summary>
public class Category : BaseEntity
{
    /// <summary>
    ///     The display name of the category.
    /// </summary>
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    /// <summary>
    ///     URL-friendly slug version of the category name, used for routing or SEO.
    /// </summary>
    [MaxLength(200)]
    public string? Slug { get; set; }

    /// <summary>
    ///     Optional detailed description about this category.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Determines the display order for the category in lists or UI.
    ///     Lower numbers show first.
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    ///     Navigation property for questions belonging to this category.
    /// </summary>
    public ICollection<Question> Questions { get; set; } = new List<Question>();
}