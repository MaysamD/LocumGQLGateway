using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocumApp.Domain.Models.Profiles;

/// <summary>
///     Represents a profile's preferences including facility, shift, job, location types and states.
/// </summary>
[Table("preferences")]
public class Preference : BaseEntity
{
    /// <summary>
    ///     Foreign key to the associated profile.
    /// </summary>
    [Required]
    [Column("profile_id")]
    public int ProfileId { get; set; }

    /// <summary>
    ///     Navigation property to the associated profile.
    /// </summary>
    public Profile? Profile { get; set; }

    /// <summary>
    ///     Preferred facility types.
    /// </summary>
    public ICollection<FacilityType> FacilityTypes { get; set; } = new List<FacilityType>();

    /// <summary>
    ///     Preferred shift types.
    /// </summary>
    public ICollection<ShiftType> ShiftTypes { get; set; } = new List<ShiftType>();

    /// <summary>
    ///     Preferred job types.
    /// </summary>
    public ICollection<JobType> JobTypes { get; set; } = new List<JobType>();

    /// <summary>
    ///     Preferred location types.
    /// </summary>
    public ICollection<LocationType> LocationTypes { get; set; } = new List<LocationType>();

    /// <summary>
    ///     Preferred states or provinces.
    /// </summary>
    public ICollection<State> States { get; set; } = new List<State>();
}