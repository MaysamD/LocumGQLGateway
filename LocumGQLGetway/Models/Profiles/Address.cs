using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocumGQLGateway.Models.Profiles;

namespace LocumGQLGateway.Models.Profiles
{
    /// <summary>
    /// Represents a physical address associated with a profile.
    /// </summary>
    public class Address : BaseEntity
    {
        /// <summary>
        /// Primary street address line, e.g., "123 Main St".
        /// </summary>
        [MaxLength(200)]
        public string? Street1 { get; set; }

        /// <summary>
        /// Secondary street address line, e.g., "Apt 4B".
        /// </summary>
        [MaxLength(200)]
        public string? Street2 { get; set; }

        /// <summary>
        /// City or locality name, e.g., "New York".
        /// </summary>
        [MaxLength(100)]
        public string? City { get; set; }

        /// <summary>
        /// Navigation property to the state/province.
        /// </summary>
        public State? State { get; set; }

        /// <summary>
        /// Foreign key for the associated state.
        /// </summary>
        [ForeignKey(nameof(State))]
        public int? StateId { get; set; }

        /// <summary>
        /// Postal or ZIP code, e.g., "10001".
        /// </summary>
        [MaxLength(20)]
        public string? PostalCode { get; set; }

        /// <summary>
        /// Country name, e.g., "United States".
        /// </summary>
        [MaxLength(100)]
        public string? Country { get; set; }

        
        /// <summary>
        /// Flag indicating if this is the primary address for the profile.
        /// </summary>
        public bool IsPrimary { get; set; } = false;
        
        /// <summary>
        /// Foreign key for the associated profile.
        /// </summary>
        [Required]
        public int ProfileId { get; set; }

        /// <summary>
        /// Navigation property to the associated profile.
        /// </summary>
        public Profile? Profile { get; set; }
    }
}