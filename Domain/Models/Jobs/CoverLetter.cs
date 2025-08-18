using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ganss.Xss;

namespace LocumApp.Domain.Models.Jobs;

/// <summary>
///     Represents a candidate's cover letter for a specific job application.
/// </summary>
[Table("cover_letters")]
public class CoverLetter : BaseEntity
{
    private string _content = string.Empty;

    /// <summary>
    ///     Gets or sets the text content of the cover letter.
    /// </summary>
    [Required]
    [Column("content", TypeName = "longtext")] // For MySQL (or nvarchar(MAX) if SQL Server)
    public string Content
    {
        get => _content;
        set => _content = value?.SanitizeHtml() ?? string.Empty;
    }

    /// <summary>
    ///     Gets or sets the ID of the candidate who wrote this cover letter.
    /// </summary>
    [Required]
    [Column("candidate_user_id")]
    public int CandidateUserId { get; set; }

    /// <summary>
    ///     Navigation property to the candidate (user) who wrote this cover letter.
    /// </summary>
    public virtual User Candidate { get; set; } = null!;
}