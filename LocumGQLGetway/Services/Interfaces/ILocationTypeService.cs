using LocumGQLGateway.Models.Profiles;

namespace LocumGQLGateway.Services.Interfaces;

public interface ILocationTypeService
{
    Task<IEnumerable<LocationType>> GetAllAsync();
    Task<LocationType?> GetByIdAsync(int id);
}