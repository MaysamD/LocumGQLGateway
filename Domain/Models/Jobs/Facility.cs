using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocumApp.Domain.Models.Profiles;

namespace LocumApp.Domain.Models.Jobs;

[Table("facilities")]
public class Facility : BaseEntity
{
    /// <summary>
    ///     Gets or sets the official name of the facility.
    /// </summary>
    [Required]
    [MaxLength(200)]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the facility type (e.g., Hospital, Clinic, Urgent Care).
    /// </summary>
    [Required]
    [MaxLength(100)]
    [Column("facility_type")]
    public FacilityType? FacilityType { get; set; }  

    /// <summary>
    ///     Gets or sets the primary address of the facility.
    /// </summary>
    [MaxLength(300)]
    [Column("address")]
    public Address? Address { get; set; }
 
    /// <summary>
    ///     Gets or sets the contact phone number of the facility.
    /// </summary>
    [MaxLength(20)]
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    ///     Gets or sets the contact email address of the facility.
    /// </summary>
    [MaxLength(150)]
    [Column("email")]
    public string? Email { get; set; }

    /// <summary>
    ///     Gets or sets the website URL of the facility.
    /// </summary>
    [MaxLength(200)]
    [Column("website")]
    public string? Website { get; set; }

    /// <summary>
    ///     Gets or sets whether the facility is active and available for job postings.
    /// </summary>
    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    /// <summary>
    ///     Gets or sets a collection of jobs associated with this facility.
    /// </summary>
    public virtual ICollection<Job>? Jobs { get; set; }
}