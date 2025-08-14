using LocumApp.Domain.Models.Profiles;
using LocumGQLGateway.Dtos;

namespace LocumGQLGateway.Services.Interfaces;

public interface IProfileService
{
    Task<IEnumerable<Profile>> GetAllAsync();
    Task<Profile?> GetProfileByUserId(int userId);
    Task<bool> UpdateAsync(ProfileDto input);
    Task<bool> UpdateProfileAddress(AddressDto input);
    Task<Profile?> GetProfileByEmail(string email);
}