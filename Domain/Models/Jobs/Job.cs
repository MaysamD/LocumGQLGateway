using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocumApp.Domain.Enums;
using LocumApp.Domain.Models.Profiles;

namespace LocumApp.Domain.Models.Jobs;

/// <summary>
///     Represents a job posting within the Locum system.
/// </summary>
[Table("jobs")]
public class Job : BaseEntity
{
    /// <summary>
    ///     Gets or sets the title of the job.
    /// </summary>
    [Required]
    [MaxLength(150)]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets a detailed description of the job.
    /// </summary>
    [Required]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the type of job (e.g., FullTime, PartTime, Locum).
    /// </summary>
    [Required]
    [Column("type")]
    public JobType? Type { get; set; }

    /// <summary>
    ///     Gets or sets the date and time the job starts.
    /// </summary>
    [Required]
    [Column("start_date")]
    public DateTime StartDate { get; set; }

    /// <summary>
    ///     Gets or sets the date and time the job ends.
    /// </summary>
    [Column("end_date")]
    public DateTime? EndDate { get; set; }

    /// <summary>
    ///     Gets or sets the minimum hourly or fixed rate for the job.
    /// </summary>
    [Column("min_rate", TypeName = "decimal(18,2)")]
    public decimal? Min_Rate { get; set; }

    /// <summary>
    ///     Gets or sets the maximum hourly or fixed rate for the job.
    /// </summary>
    [Column("max_rate", TypeName = "decimal(18,2)")]
    public decimal? Max_Rate { get; set; }

    /// <summary>
    ///     Gets or sets the currency for the job rate.
    /// </summary>
    [MaxLength(3)]
    [Column("currency")]
    public string Currency { get; set; } = "USD";

    /// <summary>
    ///     Gets or sets the location of the job.
    /// </summary>
    [Column("location")]
    public string? Location { get; set; }

    /// <summary>
    ///     Gets or sets the city of the job location.
    /// </summary>
    [Column("city")]
    public string? City { get; set; }

    /// <summary>
    ///     Gets or sets the state or province of the job location.
    /// </summary>
    [Column("state")]
    public string? State { get; set; }

    /// <summary>
    ///     Gets or sets the country of the job location.
    /// </summary>
    [MaxLength(50)]
    [Column("country")]
    public string? Country { get; set; }

    /// <summary>
    ///     Gets or sets the required specialty for the job.
    /// </summary>
    [Column("specialty")]
    public string? Specialty { get; set; }

    /// <summary>
    ///     Gets or sets any additional requirements for the job.
    /// </summary>
    [Column("requirements")]
    public string? Requirements { get; set; }

    /// <summary>
    ///     Gets or sets the job status (e.g., Open, Closed, Pending).
    /// </summary>
    [Required]
    [Column("status")]
    public JobStatus Status { get; set; } = JobStatus.Open;

    /// <summary>
    ///     Gets or sets the maximum number of candidates for the job.
    /// </summary>
    [Column("max_candidates")]
    public int? MaxCandidates { get; set; }

    /// <summary>
    ///     Gets or sets whether the job is remote.
    /// </summary>
    [Column("is_remote")]
    public bool IsRemote { get; set; } = false;

    /// <summary>
    ///     Gets or sets the facility associated with the job.
    /// </summary>
    [Column("facility_id")]
    public int? FacilityId { get; set; }

    /// <summary>
    ///     Navigation property for the associated facility.
    /// </summary>
    public virtual Facility? Facility { get; set; }

    /// <summary>
    ///     Gets or sets the user who posted the job.
    /// </summary>
    [Column("posted_by_user_id")]
    public int? PostedByUserId { get; set; }

    /// <summary>
    ///     Navigation property for the user who posted the job.
    /// </summary>
    public virtual User? PostedByUser { get; set; }

    /// <summary>
    ///     Gets or sets a collection of candidates applied to the job.
    /// </summary>
    public virtual ICollection<JobApplication>? Applications { get; set; }

    /// <summary>
    ///     Gets or sets tags for the job (e.g., "urgent", "night shift").
    /// </summary>
    [Column("tags")]
    public string? Tags { get; set; }

    /// <summary>
    ///     Gets or sets the estimated time of arrival (ETA) for credentialing.  
    ///     This value can be used to track when the credentialing process is expected 
    ///     to be completed. Stored in the database as <c>credentialing_eta</c>.
    /// </summary>
    [Column("credentialing_eta")]
    public DateTime? CredentialingEta { get; set; }


    /// <summary>
    ///     Gets or sets the estimated time of arrival (ETA) for credentialing.  
    ///     This value can be used to track when the credentialing process is expected 
    ///     to be completed. Stored in the database as <c>credentialing_eta</c>.
    /// </summary>

    /// <summary>
    /// Gets or sets a value indicating whether the job posting is restricted in visibility.  
    /// When <c>true</c>, the job is visible only to the posting user (poster) or their organization.  
    /// When <c>false</c>, the job is publicly visible to all eligible candidates.  
    /// </summary>
    [Column("is_restricted")]
    public bool IsRestricted { get; set; } = true;
} 
