using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Added for Table/Column attributes

namespace LocumApp.Domain.Models.Profiles;

/// <summary>
///     Represents a state or province used in addresses.
/// </summary>
[Table("states")] // Added Table attribute
public class State : BaseEntity
{
    /// <summary>
    ///     Full name of the state or province, e.g., "California".
    /// </summary>
    [Required]
    [MaxLength(100)]
    [Column("name")] // Added Column attribute
    public string Name { get; set; } = null!;

    /// <summary>
    ///     Abbreviation or code of the state, e.g., "CA".
    /// </summary>
    [Required]
    [MaxLength(10)]
    [Column("abbreviation")] // Added Column attribute
    public string Abbreviation { get; set; } = null!;
}