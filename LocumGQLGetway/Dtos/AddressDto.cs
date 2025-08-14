using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Dtos;

/// <summary>
///     Data Transfer Object representing a physical address for a profile.
/// </summary>
public class AddressDto
{
    /// <summary>
    ///     The ID of the profile this address belongs to.
    /// </summary>
    [Required]
    public int ProfileId { get; set; }

    /// <summary>
    ///     Primary street address line, e.g., "123 Main St".
    /// </summary>
    [MaxLength(200)]
    public string? Street1 { get; set; }

    /// <summary>
    ///     Secondary street address line, e.g., "Apt 4B".
    /// </summary>
    [MaxLength(200)]
    public string? Street2 { get; set; }

    /// <summary>
    ///     City or locality name, e.g., "New York".
    /// </summary>
    [MaxLength(100)]
    public string? City { get; set; }

    /// <summary>
    ///     Optional foreign key or lookup ID for state or province.
    /// </summary>
    public int? StateId { get; set; }

    /// <summary>
    ///     Postal or ZIP code, e.g., "10001".
    /// </summary>
    [MaxLength(20)]
    [RegularExpression(@"^[a-zA-Z0-9\s\-]+$",
        ErrorMessage = "Postal code can only contain letters, numbers, spaces, and dashes.")]

    public string? PostalCode { get; set; }

    /// <summary>
    ///     Country name, e.g., "United States".
    /// </summary>
    [MaxLength(100)]
    public string? Country { get; set; }

    /// <summary>
    ///     Flag indicating if this is the primary address for the profile.
    /// </summary>
    public bool IsPrimary { get; set; } = false;
}