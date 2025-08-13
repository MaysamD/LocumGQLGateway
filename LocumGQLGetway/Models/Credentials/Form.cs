using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Models.Credentials;

/// <summary>
///     Represents a collection of categories and questions grouped together as a form.
/// </summary>
public class Form : BaseEntity
{
    /// <summary>
    ///     Display name of the form.
    /// </summary>
    [Required]
    [MaxLength(250)]
    public string Name { get; set; } = null!;

    /// <summary>
    ///     URL-friendly slug of the form name for routing or SEO.
    /// </summary>
    [MaxLength(250)]
    public string? Slug { get; set; }

    /// <summary>
    ///     Optional description or notes about the form.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Flag indicating whether the form is currently active and visible.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    ///     Navigation property for the categories associated with this form.
    /// </summary>
    public ICollection<FormCategory> FormCategories { get; set; } = new List<FormCategory>();

    /// <summary>
    ///     Navigation property for the questions directly linked to this form.
    /// </summary>
    public ICollection<FormQuestion> FormQuestions { get; set; } = new List<FormQuestion>();
}