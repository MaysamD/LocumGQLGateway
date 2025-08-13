using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Models.Profiles
{
    /// <summary>
    /// Represents a type of location, such as Hospital, Clinic, or Office.
    /// </summary>
    public class LocationType : BaseEntity
    {
        /// <summary>
        /// The name of the location type.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        
        /// <summary>
        /// Optional description providing more details about the location type.
        /// </summary>
        [MaxLength(250)]
        public string? Description { get; set; }
    }
}