using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocumApp.Domain.Enums;

namespace LocumApp.Domain.Models.Jobs;


/// <summary>
///     Represents a note linked to a job application.
/// </summary>
[Table("job_application_notes")]
public class JobApplicationNote : BaseEntity
{
    /// <summary>
    ///     Gets or sets the content of the note.
    /// </summary>
    [Required]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the ID of the related job application.
    /// </summary>
    [Required]
    public int JobApplicationId { get; set; }

    /// <summary>
    ///     Navigation property for the related job application.
    /// </summary>
    public virtual JobApplication JobApplication { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the role of the note author (Candidate, Poster, credentialing team).
    /// </summary>
    [Required]
    public NoteAuthorType AuthorType { get; set; } 
}

