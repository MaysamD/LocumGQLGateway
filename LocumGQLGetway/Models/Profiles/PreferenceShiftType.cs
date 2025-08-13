namespace LocumGQLGateway.Models.Profiles;

/// <summary>
///     Represents the relationship between a user's preference and a shift type.
///     This is typically used as a join entity in a many-to-many relationship
///     between <see cref="Preference"/> and <see cref="ShiftType"/>.
/// </summary>
public class PreferenceShiftType
{
    /// <summary>
    ///     Gets or sets the identifier of the associated shift type.
    /// </summary>
    public int ShiftTypeId { get; set; }

    /// <summary>
    ///     Gets or sets the identifier of the associated preference.
    /// </summary>
    public int PreferenceId { get; set; }
}