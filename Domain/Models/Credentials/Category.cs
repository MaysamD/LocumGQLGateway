using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocumApp.Domain.Models.Credentials;

/// <summary>
///     Represents a category grouping for questions or credentials.
/// </summary>
[Table("categories")]
public class Category : BaseEntity
{
    /// <summary>
    ///     The display name of the category.
    /// </summary>
    [Required]
    [MaxLength(200)]
    [Column("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    ///     URL-friendly slug version of the category name, used for routing or SEO.
    /// </summary>
    [MaxLength(200)]
    [Column("slug")]
    public string? Slug { get; set; }

    /// <summary>
    ///     Optional detailed description about this category.
    /// </summary>
    [Column("description")]
    public string? Description { get; set; }

    /// <summary>
    ///     Navigation property for questions belonging to this category.
    /// </summary>
    public ICollection<Question> Questions { get; set; } = new List<Question>();

    /// <summary>
    ///     Navigation property for Forms belonging to this category.
    /// </summary>
    public IEnumerable<Form>? Forms { get; set; }
}