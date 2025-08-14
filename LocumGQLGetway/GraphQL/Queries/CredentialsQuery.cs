using LocumGQLGateway.Models.Credentials;
using LocumGQLGateway.Services.Interfaces;

namespace LocumGQLGateway.GraphQL.Queries;

public partial class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IQueryable<Category>> GetCredentialsCategoriesAsync([Service] ICredentialsService credentialsService)
    {
        return credentialsService.GetCredentialsCategoriesAsync();
    }

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IQueryable<Form>> GetCredentialsFormsAsync([Service] ICredentialsService credentialsService)
    {
        return credentialsService.GetCredentialsFormsAsync();
    }
}