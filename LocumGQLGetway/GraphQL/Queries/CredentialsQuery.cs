using System.Net;
using LocumGQLGateway.Models.Credentials;

namespace LocumGQLGateway.GraphQL.Queries;

public partial class Query
{
    [UseProjection]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public async Task <IEnumerable<Category>> GetCredentialsCategoriesAsync([Service] ICredentialsService credentialsService)
    {
        return await credentialsService.GetCredentialsCategoriesAsync();
    }
}

public interface ICredentialsService
{
    Task <IEnumerable<Category>>  GetCredentialsCategoriesAsync();
}