using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LocumApp.Domain.Enums;
using LocumApp.Domain.Models.Profiles;

namespace LocumApp.Domain.Models;

/// <summary>
///     Represents a system user with authentication and authorization details.
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    ///     The username for login. Optional, but recommended to be unique.
    /// </summary>
    [MaxLength(100)]
    public string? Username { get; set; }

    /// <summary>
    ///     The email address of the user.
    /// </summary>
    [MaxLength(256)]
    [EmailAddress]
    public string? Email { get; set; }

    /// <summary>
    ///     Indicates whether the user's email address has been confirmed.
    /// </summary>
    [Column("email_confirmed")]
    public bool EmailConfirmed { get; set; } = false;

    /// <summary>
    ///     The hashed password for authentication.
    /// </summary>
    [MaxLength(256)]
    [Column("password_hash")]
    public string? PasswordHash { get; set; }

    /// <summary>
    ///     The role assigned to the user for authorization.
    /// </summary>
    public Role? Role { get; set; }

    /// <summary>
    ///     Navigation property to the user’s profile containing personal details.
    /// </summary>
    public Profile? Profile { get; set; }
}