using LocumApp.Domain.Models.Profiles;
using LocumGQLGateway.Dtos;

namespace LocumGQLGateway.Services.Interfaces;

public interface IPreferenceService
{
    Task<Preference?> GetByProfileIdAsync(int profileId);
    Task<bool> UpdateProfilePreference(PreferenceDto input);
}