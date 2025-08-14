using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocumApp.Domain.Models.Profiles;

/// <summary>
///     Represents a type of location, such as Hospital, Clinic, or Office.
/// </summary>
[Table("location_types")]
public class LocationType : BaseEntity
{
    /// <summary>
    ///     The name of the location type.
    /// </summary>
    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    ///     Optional description providing more details about the location type.
    /// </summary>
    [MaxLength(250)]
    [Column("description")]
    public string? Description { get; set; }
}