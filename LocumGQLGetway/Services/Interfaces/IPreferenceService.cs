using LocumGQLGateway.Dtos;
using LocumGQLGateway.Models.Profiles;

namespace LocumGQLGateway.Services.Interfaces;

public interface IPreferenceService
{
    Task<Preference?> GetByProfileIdAsync(int profileId);
    Task<bool> UpdateProfilePreference(PreferenceDto input);
}