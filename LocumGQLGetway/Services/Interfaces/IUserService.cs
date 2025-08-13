using LocumGQLGateway.Dtos;
using LocumGQLGateway.Models;

namespace LocumGQLGateway.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User> AddAsync(AddUserDto input);
    Task UpdatePasswordAsync(UpdatePasswordDto input);
}