using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Models.Credentials;

/// <summary>
///     Represents the association of a Question with a Form, including form-specific settings like requiredness and
///     ordering.
/// </summary>
public class FormQuestion : BaseEntity
{
    /// <summary>
    ///     Foreign key referencing the associated form.
    /// </summary>
    [Required]
    public int FormId { get; set; }

    /// <summary>
    ///     Navigation property to the associated form.
    /// </summary>
    public Form Form { get; set; } = null!;

    /// <summary>
    ///     Foreign key referencing the associated question.
    /// </summary>
    [Required]
    public int QuestionId { get; set; }

    /// <summary>
    ///     Navigation property to the associated question.
    /// </summary>
    public Question Question { get; set; } = null!;

    /// <summary>
    ///     Order in which this question appears within the form.
    ///     Lower values appear earlier.
    /// </summary>
    public int SortOrder { get; set; }
}