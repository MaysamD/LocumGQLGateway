using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocumApp.Domain.Models.Credentials;

/// <summary>
///     Represents a collection of categories and questions grouped together as a form.
/// </summary>
[Table("forms")]
public class Form : BaseEntity
{
    /// <summary>
    ///     Display name of the form.
    /// </summary>
    [Required]
    [MaxLength(250)]
    [Column("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    ///     URL-friendly slug of the form name for routing or SEO.
    /// </summary>
    [MaxLength(250)]
    [Column("slug")]
    public string? Slug { get; set; }

    /// <summary>
    ///     Optional description or notes about the form.
    /// </summary>
    [Column("description")]
    public string? Description { get; set; }

    /// <summary>
    ///     Flag indicating whether the form is currently active and visible.
    /// </summary>
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    /// <summary>
    ///     Navigation property for the categories associated with this form.
    /// </summary>
    public ICollection<Category> Categories { get; set; } = new List<Category>();
}