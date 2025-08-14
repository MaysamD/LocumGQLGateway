using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Dtos;

/// <summary>
///     Data Transfer Object representing a user profile's basic information.
/// </summary>
public class ProfileDto
{
    private const string PhoneRegex =
        @"^(\+1\s?)?(\(?[2-9]\d{2}\)?[\s\-]?)?[2-9]\d{2}[\s\-]?\d{4}$";

    /// <summary>
    ///     Gets or sets the unique identifier of the profile.
    /// </summary>
    [Required(ErrorMessage = "ProfileId is required.")]
    public required int ProfileId { get; set; }

    /// <summary>
    ///     Gets or sets the first name of the profile.
    ///     Maximum length is 100 characters.
    /// </summary>
    [MaxLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
    public string? FirstName { get; set; }

    /// <summary>
    ///     Gets or sets the last name of the profile.
    ///     Maximum length is 100 characters.
    /// </summary>
    [MaxLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
    public string? LastName { get; set; }

    /// <summary>
    ///     Gets or sets the phone number of the profile.
    ///     Must conform to North American phone number format.
    ///     Maximum length is 20 characters.
    /// </summary>
    [MaxLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
    [RegularExpression(PhoneRegex, ErrorMessage = "Invalid phone number format.")]
    public string? PhoneNumber { get; set; }
}