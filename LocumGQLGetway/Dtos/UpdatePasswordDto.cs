using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Dtos;

/// <summary>
///     Data transfer object for updating a user's password.
/// </summary>
public class UpdatePasswordDto
{
    /// <summary>
    ///     The identifier of the user whose password is being updated.
    /// </summary>
    [Required]
    public int UserId { get; set; }

    /// <summary>
    ///     The current password of the user.
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    [MaxLength(100)]
    [MinLength(8, ErrorMessage = "Old password must be at least 8 characters long.")]
    public string OldPassword { get; set; } = null!;

    /// <summary>
    ///     The new password the user wants to set.
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    [MaxLength(100)]
    [MinLength(8, ErrorMessage = "New password must be at least 8 characters long.")]
    public string NewPassword { get; set; } = null!;
}