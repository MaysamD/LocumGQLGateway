using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocumApp.Domain.Models.Credentials;

/// <summary>
///     Represents a selectable option for a question, typically used in multiple choice scenarios.
/// </summary>
[Table("question_options")]
public class QuestionOption : BaseEntity
{
    /// <summary>
    ///     Foreign key referencing the question this option belongs to.
    /// </summary>
    [Required]
    [Column("question_id")]
    public int QuestionId { get; set; }

    /// <summary>
    ///     Navigation property to the parent question.
    /// </summary>
    public Question Question { get; set; } = null!;

    /// <summary>
    ///     The internal value or code of the option, used for storage or processing.
    /// </summary>
    [Required]
    [MaxLength(200)]
    [Column("value")]
    public string Value { get; set; } = null!;

    /// <summary>
    ///     Optional display text shown to users. If null, <see cref="Value" /> can be used.
    /// </summary>
    [MaxLength(500)]
    [Column("display_text")]
    public string? DisplayText { get; set; }

    /// <summary>
    ///     Order in which this option appears relative to other options.
    ///     Lower values appear first.
    /// </summary>
    [Column("sort_order")]
    public int SortOrder { get; set; }
}