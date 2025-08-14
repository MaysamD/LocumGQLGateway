namespace LocumApp.Domain.Enums;

/// <summary>
///     Represents the method or state of validation for an entity (e.g., user identity, credentials, or data).
/// </summary>
public enum ValidationMethod
{
    /// <summary>
    ///     The entity has not yet been validated.
    /// </summary>
    NotValidated = 0,

    /// <summary>
    ///     Validation performed manually by an admin or reviewer.
    /// </summary>
    Manual = 1,

    /// <summary>
    ///     Validation based on documents provided by the user.
    /// </summary>
    ProvidedDocument = 2,

    /// <summary>
    ///     Validation performed through an external API or third-party service.
    /// </summary>
    ExternalApi = 3,

    /// <summary>
    ///     Validation performed automatically using internal business rules or algorithms.
    /// </summary>
    InternalSystem = 4,

    /// <summary>
    ///     Validation skipped or not required for the given case.
    /// </summary>
    None = 5,

    /// <summary>
    ///     The credential or entity has expired and is no longer valid.
    /// </summary>
    Expired = 6
}