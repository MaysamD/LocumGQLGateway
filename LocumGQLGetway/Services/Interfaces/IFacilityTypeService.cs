using LocumApp.Domain.Models.Profiles;

namespace LocumGQLGateway.Services.Interfaces;

public interface IFacilityTypeService
{
    Task<IEnumerable<FacilityType>> GetAllAsync();
    Task<FacilityType?> GetByIdAsync(int id);
}