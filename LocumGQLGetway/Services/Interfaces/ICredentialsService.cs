using LocumGQLGateway.Models.Credentials;

namespace LocumGQLGateway.Services.Interfaces;

public interface ICredentialsService
{
    Task<IQueryable<Category>> GetCredentialsCategoriesAsync();
    Task<IQueryable<Form>> GetCredentialsFormsAsync();
}