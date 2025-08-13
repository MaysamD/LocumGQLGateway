using LocumGQLGateway.Models.Profiles;

namespace LocumGQLGateway.Services.Interfaces;

public interface IJobTypeService
{
    Task<IEnumerable<JobType>> GetAllAsync();
    Task<JobType?> GetByIdAsync(int id);
}