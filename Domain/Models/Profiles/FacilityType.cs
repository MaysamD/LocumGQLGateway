using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocumApp.Domain.Models.Profiles;

/// <summary>
///     Represents a type of facility, such as Hospital, Clinic, or Laboratory.
/// </summary>
[Table("facility_types")]
public class FacilityType : BaseEntity
{
    /// <summary>
    ///     The name of the facility type.
    /// </summary>
    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    ///     Optional description providing additional details about the facility type.
    /// </summary>
    [MaxLength(250)]
    [Column("description")]
    public string? Description { get; set; }
}