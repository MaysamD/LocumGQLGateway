using LocumGQLGateway.Models.Profiles;

namespace LocumGQLGateway.Services.Interfaces;

public interface IStateService
{
    Task<IEnumerable<State>> GetAllAsync();
    Task<State?> GetByIdAsync(int id);
}