using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Models.Profiles
{
    /// <summary>
    /// Represents a user profile with personal and preference details.
    /// </summary>
    public class Profile : BaseEntity
    {
        private const string PhoneRegex =
            @"^(\+1\s?)?(\(?[2-9]\d{2}\)?[\s\-]?)?[2-9]\d{2}[\s\-]?\d{4}$";

        /// <summary>
        /// Foreign key to the associated user account.
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Navigation property to the associated user.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// First name of the profile owner.
        /// </summary>
        [MaxLength(100)]
        public string? FirstName { get; set; }

        /// <summary>
        /// Last name of the profile owner.
        /// </summary>
        [MaxLength(100)]
        public string? LastName { get; set; }

        /// <summary>
        /// Phone number for contact, validated against North American format.
        /// </summary>
        [MaxLength(20)]
        [RegularExpression(PhoneRegex, ErrorMessage = "Invalid phone number format.")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Navigation property to the user's preferences.
        /// </summary>
        public Preference? Preference { get; set; }

        /// <summary>
        /// Navigation property to the user's notification settings.
        /// </summary>
        public ProfileNotificationSettings? ProfileNotificationSettings { get; set; }

        /// <summary>
        /// Navigation property to the user's primary address.
        /// </summary>
        public Address? Address { get; set; }
    }
}