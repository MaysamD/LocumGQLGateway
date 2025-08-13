using LocumGQLGateway.Models.Profiles;
using LocumGQLGateway.Services.Interfaces;

namespace LocumGQLGateway.GraphQL.Queries;

public partial class Query
{
    /// <summary>
    /// Retrieves all profiles with projection, filtering, and sorting support.
    /// </summary>
    /// <param name="profileService">Injected profile service.</param>
    /// <returns>Collection of profiles.</returns>
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IEnumerable<Profile>> GetProfiles([Service] IProfileService profileService) =>
        profileService.GetAllAsync();

    /// <summary>
    /// Retrieves a single profile by user ID with projection and filtering.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <param name="profileService">Injected profile service.</param>
    /// <returns>A matching profile or null.</returns>
    [UseProjection]
    [UseFiltering]
    public Task<Profile?> GetProfileByUserId(int userId, [Service] IProfileService profileService) =>
        profileService.GetProfileByUserId(userId);
    
    /// <summary>
    /// Retrieves a single profile by email with projection and filtering.
    /// </summary>
    /// <param name="email">user mail.</param>
    /// <param name="profileService">Injected profile service.</param>
    /// <returns>A matching profile or null.</returns>
    [UseProjection]
    [UseFiltering]
    public Task<Profile?> GetProfileByEmail(string email, [Service] IProfileService profileService) =>
        profileService.GetProfileByEmail(email);
     
}