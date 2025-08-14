namespace LocumGQLGateway.Dtos;

/// <summary>
///     Data Transfer Object for user profile preferences.
///     Contains IDs of selected facility, shift, job, location types, and states.
/// </summary>
public class PreferenceDto
{
    /// <summary>
    ///     Gets or sets the ID of the associated profile.
    /// </summary>
    public required int ProfileId { get; set; }

    /// <summary>
    ///     Gets or sets the list of preferred facility type IDs.
    /// </summary>
    public List<int> FacilityTypeIds { get; set; } = [];

    /// <summary>
    ///     Gets or sets the list of preferred shift type IDs.
    /// </summary>
    public List<int> ShiftTypeIds { get; set; } = [];

    /// <summary>
    ///     Gets or sets the list of preferred job type IDs.
    /// </summary>
    public List<int> JobTypeIds { get; set; } = [];

    /// <summary>
    ///     Gets or sets the list of preferred location type IDs.
    /// </summary>
    public List<int> LocationTypeIds { get; set; } = [];

    /// <summary>
    ///     Gets or sets the list of preferred state IDs.
    /// </summary>
    public List<int> StateIds { get; set; } = [];
}