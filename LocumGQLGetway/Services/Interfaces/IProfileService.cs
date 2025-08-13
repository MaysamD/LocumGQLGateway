using LocumGQLGateway.Data;
using LocumGQLGateway.Dtos;
using LocumGQLGateway.Models.Profiles;

namespace LocumGQLGateway.Services.Interfaces;

public interface IProfileService
{
    Task<IEnumerable<Profile>> GetAllAsync();
    Task<Profile?> GetProfileByUserId(int userId);
    Task<bool> UpdateAsync(ProfileDto input);
    Task<bool> UpdateProfileAddress(AddressDto input);
    Task<Profile?> GetProfileByEmail(string email);
}