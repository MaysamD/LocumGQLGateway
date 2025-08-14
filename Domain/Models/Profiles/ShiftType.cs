using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Added for Table/Column attributes

namespace LocumApp.Domain.Models.Profiles;

/// <summary>
///     Represents a type of work shift (e.g., Day, Night, Evening).
/// </summary>
[Table("shift_types")] // Added Table attribute
public class ShiftType : BaseEntity
{
    /// <summary>
    ///     Name of the shift type.
    /// </summary>
    [Required]
    [MaxLength(100)]
    [Column("name")] // Added Column attribute
    public string Name { get; set; } = null!;

    /// <summary>
    ///     Optional description providing more details about the shift type.
    /// </summary>
    [MaxLength(250)]
    [Column("description")] // Added Column attribute
    public string? Description { get; set; }
}