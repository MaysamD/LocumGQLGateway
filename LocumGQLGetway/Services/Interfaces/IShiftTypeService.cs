using LocumGQLGateway.Models.Profiles;

namespace LocumGQLGateway.Services.Interfaces;

public interface IShiftTypeService
{
    Task<IEnumerable<ShiftType>> GetAllAsync();
    Task<ShiftType?> GetByIdAsync(int id);
}