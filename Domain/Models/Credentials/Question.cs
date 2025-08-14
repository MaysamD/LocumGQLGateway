using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocumApp.Domain.Enums;

namespace LocumApp.Domain.Models.Credentials;

/// <summary>
///     Represents a question that belongs to a category and can have options if applicable.
/// </summary>
[Table("questions")]
public class Question : BaseEntity
{
    /// <summary>
    ///     Foreign key referencing the category this question belongs to.
    /// </summary>
    [Required]
    [Column("category_id")]
    public int CategoryId { get; set; }

    /// <summary>
    ///     Navigation property to the question's category.
    /// </summary>
    public Category Category { get; set; } = null!;

    /// <summary>
    ///     The main text of the question to be presented.
    /// </summary>
    [Required]
    [Column("text")]
    public string Text { get; set; } = null!;

    /// <summary>
    ///     Optional help or hint text to guide the user answering the question.
    /// </summary>
    [Column("help_text")]
    public string? HelpText { get; set; }

    /// <summary>
    ///     The data type of the expected answer.
    ///     Consider replacing with an enum for type safety.
    ///     Examples: "Text", "Number", "Date", "Boolean", "MultipleChoice", etc.
    /// </summary>
    [Required]
    [MaxLength(50)]
    [Column("data_type")]
    public QuestionDataType DataType { get; set; } = QuestionDataType.Text;

    /// <summary>
    ///     Defines the order in which this question appears within its category or form.
    ///     Lower numbers appear first.
    /// </summary>
    [Column("sort_order")]
    public int SortOrder { get; set; }

    /// <summary>
    ///     Collection of options available for questions with selectable answers.
    ///     Empty for free-text or numeric questions.
    /// </summary>
    public ICollection<QuestionOption> Options { get; set; } = new List<QuestionOption>();

    /// <summary>
    ///     An optional regular expression pattern used to validate the answer.
    ///     If provided, user input must match this pattern to be considered valid.
    ///     Example: <c>^\d{10}$</c> for a 10-digit number.
    /// </summary>
    public string? RegexValidation { get; set; }
}