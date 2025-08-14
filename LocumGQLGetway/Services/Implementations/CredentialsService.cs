using LocumApp.Domain.Models.Credentials;
using LocumGQLGateway.Data;
using LocumGQLGateway.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocumGQLGateway.Services.Implementations;

public class CredentialsService : ICredentialsService
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public CredentialsService(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    public Task<IQueryable<Category>> GetCredentialsCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Form>> GetCredentialsFormsAsync()
    {
        var ctx = _factory.CreateDbContext();
        var query = ctx.Forms
            .Include(p => p.Categories)
            .ThenInclude(q => q.Questions);

        return Task.FromResult(query.AsQueryable());
    }
}