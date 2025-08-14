using LocumGQLGateway.Models.Profiles;
using LocumGQLGateway.Services.Interfaces;

namespace LocumGQLGateway.GraphQL.Queries;

/// <summary>
///     GraphQL root query definitions for retrieving profile-related preferences,
///     location types, facility types, shift types, job types, and states.
/// </summary>
public partial class Query
{
    // ===== Preferences =====

    /// <summary>
    ///     Retrieves preference settings for a given profile.
    /// </summary>
    /// <param name="profileId">Profile identifier.</param>
    /// <param name="prefService">Injected preference service.</param>
    [UseProjection]
    [UseFiltering]
    public Task<Preference?> GetPreferenceByProfileId(
        int profileId,
        [Service] IPreferenceService prefService)
    {
        return prefService.GetByProfileIdAsync(profileId);
    }

    // ===== Location Types =====

    /// <summary>
    ///     Retrieves all available location types.
    /// </summary>
    [UseFiltering]
    [UseSorting]
    public Task<IEnumerable<LocationType>> GetLocationTypesAsync(
        [Service] ILocationTypeService locationTypeService)
    {
        return locationTypeService.GetAllAsync();
    }

    /// <summary>
    ///     Retrieves a location type by its ID.
    /// </summary>
    public Task<LocationType?> GetLocationTypeByIdAsync(
        int id,
        [Service] ILocationTypeService locationTypeService)
    {
        return locationTypeService.GetByIdAsync(id);
    }

    // ===== Facility Types =====

    /// <summary>
    ///     Retrieves all available facility types.
    /// </summary>
    [UseFiltering]
    [UseSorting]
    public Task<IEnumerable<FacilityType>> GetFacilityTypesAsync(
        [Service] IFacilityTypeService facilityTypeService)
    {
        return facilityTypeService.GetAllAsync();
    }

    /// <summary>
    ///     Retrieves a facility type by its ID.
    /// </summary>
    public Task<FacilityType?> GetFacilityTypeByIdAsync(
        int id,
        [Service] IFacilityTypeService facilityTypeService)
    {
        return facilityTypeService.GetByIdAsync(id);
    }

    // ===== Shift Types =====

    /// <summary>
    ///     Retrieves all available shift types.
    /// </summary>
    [UseFiltering]
    [UseSorting]
    public Task<IEnumerable<ShiftType>> GetShiftTypesAsync(
        [Service] IShiftTypeService shiftTypeService)
    {
        return shiftTypeService.GetAllAsync();
    }

    /// <summary>
    ///     Retrieves a shift type by its ID.
    /// </summary>
    public Task<ShiftType?> GetShiftTypeByIdAsync(
        int id,
        [Service] IShiftTypeService shiftTypeService)
    {
        return shiftTypeService.GetByIdAsync(id);
    }

    // ===== Job Types =====

    /// <summary>
    ///     Retrieves all available job types.
    /// </summary>
    [UseFiltering]
    [UseSorting]
    public Task<IEnumerable<JobType>> GetJobTypesAsync(
        [Service] IJobTypeService jobTypeService)
    {
        return jobTypeService.GetAllAsync();
    }

    /// <summary>
    ///     Retrieves a job type by its ID.
    /// </summary>
    public Task<JobType?> GetJobTypeByIdAsync(
        int id,
        [Service] IJobTypeService jobTypeService)
    {
        return jobTypeService.GetByIdAsync(id);
    }

    // ===== States =====

    /// <summary>
    ///     Retrieves all available states.
    /// </summary>
    [UseFiltering]
    [UseSorting]
    public Task<IEnumerable<State>> GetStatesAsync(
        [Service] IStateService stateService)
    {
        return stateService.GetAllAsync();
    }

    /// <summary>
    ///     Retrieves a state by its ID.
    /// </summary>
    public Task<State?> GetStateByIdAsync(
        int id,
        [Service] IStateService stateService)
    {
        return stateService.GetByIdAsync(id);
    }
}