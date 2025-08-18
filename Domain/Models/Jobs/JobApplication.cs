using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocumApp.Domain.Enums;

namespace LocumApp.Domain.Models.Jobs;

/// <summary>
///     Represents an application submitted by a candidate (locum) for a specific job.
/// </summary>
[Table("job_applications")]
public class JobApplication : BaseEntity
{
    /// <summary>
    ///     Gets or sets the ID of the job being applied to.
    /// </summary>
    [Required]
    [Column("job_id")]
    public int JobId { get; set; }

    /// <summary>
    ///     Navigation property to the associated job.
    /// </summary>
    public virtual Job Job { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the ID of the candidate (profile/user) applying to the job.
    /// </summary>
    [Required]
    [Column("candidate_User_id")]
    public int CandidateUserId { get; set; }

    /// <summary>
    ///     Navigation User to the candidate (profile).
    /// </summary>
    public virtual User Candidate { get; set; } = null!;

    /// <summary>
    ///     Gets or sets the date and time the application was submitted.
    /// </summary>
    [Column("applied_at")]
    public DateTime AppliedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    ///     Gets or sets the current status of the job application.
    /// </summary>
    [Required]
    [Column("status")]
    public JobApplicationStatus Status { get; set; } = JobApplicationStatus.Submitted;

    /// <summary>
    ///     Gets or sets the foreign key to the candidate's cover letter.
    /// </summary>
    [Column("cover_letter_id")]
    public int? CoverLetterId { get; set; }

    /// <summary>
    ///     Navigation property to the cover letter entity.
    /// </summary>
    public virtual CoverLetter? CoverLetter { get; set; }

    /// <summary>
    ///     Gets or sets candidate-specific private notes (not shared with  credentialing team  or poster).
    /// </summary>
    [MaxLength(2000)]
    [Column("candidate_notes")]
    public virtual ICollection<JobApplicationNote>?  CandidateNotes { get; set; }

    /// <summary>
    ///     Gets or sets notes created by the credentialing team while reviewing the application.
    /// </summary>
    [MaxLength(2000)]
    [Column("credentialing_notes")]
    public virtual ICollection<JobApplicationNote>?  CredentialingNotes { get; set; }
    
    /// <summary>
    ///     Gets or sets notes created by the job poster or recruiter (e.g., facility HR).
    /// </summary>
    [MaxLength(2000)]
    [Column("poster_notes")]
    public virtual ICollection<JobApplicationNote>?  PosterNotes { get; set; }
}
 