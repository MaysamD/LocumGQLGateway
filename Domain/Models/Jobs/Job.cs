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
    public string Title { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets a detailed description of the job.
    /// </summary>
    [Required]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the type of job (e.g., FullTime, PartTime, Locum).
    /// </summary>
    [Required]
    public JobType? Type { get; set; }

    /// <summary>
    ///     Gets or sets the date and time the job starts.
    /// </summary>
    [Required]
    public DateTime StartDate { get; set; }

    /// <summary>
    ///     Gets or sets the date and time the job ends.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    ///     Gets or sets the hourly or fixed rate for the job.
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal? Rate { get; set; }

    /// <summary>
    ///     Gets or sets the currency for the job rate.
    /// </summary>
    [MaxLength(3)]
    public string Currency { get; set; } = "USD";

    /// <summary>
    ///     Gets or sets the location of the job.
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    ///     Gets or sets the city of the job location.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    ///     Gets or sets the state or province of the job location.
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    ///     Gets or sets the country of the job location.
    /// </summary>
    [MaxLength(50)]
    public string? Country { get; set; }

    /// <summary>
    ///     Gets or sets the required specialty for the job.
    /// </summary>
    public string? Specialty { get; set; }

    /// <summary>
    ///     Gets or sets any additional requirements for the job.
    /// </summary>
    public string? Requirements { get; set; }

    /// <summary>
    ///     Gets or sets the job status (e.g., Open, Closed, Pending).
    /// </summary>
    [Required]
    public JobStatus Status { get; set; } = JobStatus.Open;

    /// <summary>
    ///     Gets or sets the maximum number of candidates for the job.
    /// </summary>
    public int? MaxCandidates { get; set; }

    /// <summary>
    ///     Gets or sets whether the job is remote.
    /// </summary>
    public bool IsRemote { get; set; } = false;

    /// <summary>
    ///     Gets or sets the facility associated with the job.
    /// </summary>
    public int? FacilityId { get; set; }

    /// <summary>
    ///     Navigation property for the associated facility.
    /// </summary>
    public virtual Facility? Facility { get; set; }

    /// <summary>
    ///     Gets or sets the user who posted the job.
    /// </summary>
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
    public string? Tags { get; set; }
}

public class Facility
{
}

public class JobApplication
{
}

 