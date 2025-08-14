using LocumApp.Domain.Models.Profiles;
using LocumGQLGateway.Data;
using LocumGQLGateway.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocumGQLGateway.Services.Implementations;

public class StateService : IStateService
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public StateService(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<State>> GetAllAsync()
    {
        await using var ctx = _factory.CreateDbContext();
        return await ctx.States.ToListAsync();
    }

    public async Task<State?> GetByIdAsync(int id)
    {
        await using var ctx = _factory.CreateDbContext();
        return await ctx.States.FindAsync(id);
    }
}