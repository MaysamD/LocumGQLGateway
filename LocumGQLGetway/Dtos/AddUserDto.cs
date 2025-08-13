using System.ComponentModel.DataAnnotations;
using LocumGQLGateway.Enums;
using LocumGQLGateway.Models;

namespace LocumGQLGateway.Dtos
{
    /// <summary>
    /// Data Transfer Object for user information, typically used in API requests and responses.
    /// </summary>
    public class AddUserDto
    {
        /// <summary>
        /// Unique identifier of the user. Optional in create requests.
        /// </summary>
        public int? Id { get; set; }
        
        /// <summary>
        /// Unique username for the user. Optional in some contexts.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string? Username { get; set; }

        /// <summary>
        /// User's email address. Must be a valid email format if provided.
        /// </summary>
        [MaxLength(256)]
        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        /// <summary>
        /// Password for the user. Should be handled securely and never exposed in responses.
        /// Optional for update operations where password is not changed.
        /// </summary>
        [MaxLength(100)]
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string? Password { get; set; }

        /// <summary>
        /// Role assigned to the user, defining permissions and access level.
        /// </summary>
       
        [Required]
        public Role? Role { get; set; } 
    }
}