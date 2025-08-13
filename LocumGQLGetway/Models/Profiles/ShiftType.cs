using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Models.Profiles
{
    /// <summary>
    /// Represents a type of work shift (e.g., Day, Night, Evening).
    /// </summary>
    public class ShiftType : BaseEntity
    {
        /// <summary>
        /// Name of the shift type.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Optional description providing more details about the shift type.
        /// </summary>
        [MaxLength(250)]
        public string? Description { get; set; }
    }
}