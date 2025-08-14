using LocumGQLGateway.Dtos;
using LocumGQLGateway.Extensions;
using LocumGQLGateway.Services.Interfaces;

namespace LocumGQLGateway.GraphQL.Mutations;

/// <summary>
///     GraphQL mutation resolver class handling profile-related update operations.
/// </summary>
public partial class Mutation
{
    /// <summary>
    ///     Updates the user's profile information.
    /// </summary>
    /// <param name="input">The profile data transfer object containing updated profile details.</param>
    /// <param name="profileService">Injected profile service to handle profile operations.</param>
    /// <returns>True if the update succeeds; otherwise, false.</returns>
    /// <exception cref="ValidationException">Thrown when input validation fails.</exception>
    public async Task<bool> UpdateProfile(ProfileDto input, [Service] IProfileService profileService)
    {
        input.ValidateDataAnnotations();
        return await profileService.UpdateAsync(input);
    }

    /// <summary>
    ///     Updates the preferences associated with a user profile.
    /// </summary>
    /// <param name="input">The preference data transfer object containing updated preference details.</param>
    /// <param name="prefService">Injected preference service to handle preference operations.</param>
    /// <returns>True if the update succeeds; otherwise, false.</returns>
    /// <exception cref="ValidationException">Thrown when input validation fails.</exception>
    public async Task<bool> UpdateProfilePreference(PreferenceDto input, [Service] IPreferenceService prefService)
    {
        input.ValidateDataAnnotations();
        return await prefService.UpdateProfilePreference(input);
    }

    /// <summary>
    ///     Updates the address information for a user profile.
    /// </summary>
    /// <param name="input">The address data transfer object containing updated address details.</param>
    /// <param name="profileService">Injected profile service to handle address operations.</param>
    /// <returns>True if the update succeeds; otherwise, false.</returns>
    /// <exception cref="ValidationException">Thrown when input validation fails.</exception>
    public async Task<bool> UpdateProfileAddress(AddressDto input, [Service] IProfileService profileService)
    {
        input.ValidateDataAnnotations();
        return await profileService.UpdateProfileAddress(input);
    }
}