namespace LocumGQLGateway.Enums;

/// <summary>
///     Represents different user roles with varying permissions and access levels within the system.
/// </summary>
public enum Role
{
    /// <summary>
    ///     Super administrator with highest level of privileges.
    /// </summary>
    SuperAdmin = 0,

    /// <summary>
    ///     Locum user, typically a temporary or contract medical professional.
    /// </summary>
    Locum = 1,

    /// <summary>
    ///     Medical user such as doctors, nurses, or other healthcare staff.
    /// </summary>
    MedicalUser = 2,

    /// <summary>
    ///     Credentialer responsible for verifying and managing credentials.
    /// </summary>
    Credentialer = 3,

    /// <summary>
    ///     Administrator with broad management capabilities.
    /// </summary>
    Admin = 4
}