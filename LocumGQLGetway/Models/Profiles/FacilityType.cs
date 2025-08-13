using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Models.Profiles
{
    /// <summary>
    /// Represents a type of facility, such as Hospital, Clinic, or Laboratory.
    /// </summary>
    public class FacilityType : BaseEntity
    {
        /// <summary>
        /// The name of the facility type.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Optional description providing additional details about the facility type.
        /// </summary>
        [MaxLength(250)]
        public string? Description { get; set; } 
    }
}