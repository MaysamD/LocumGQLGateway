using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Models.Profiles
{
    /// <summary>
    /// Represents a state or province used in addresses.
    /// </summary>
    public class State : BaseEntity
    {
        /// <summary>
        /// Full name of the state or province, e.g., "California".
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Abbreviation or code of the state, e.g., "CA".
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Abbreviation { get; set; } = null!;
    }
}