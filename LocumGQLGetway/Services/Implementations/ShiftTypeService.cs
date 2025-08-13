using LocumGQLGateway.Data;
using LocumGQLGateway.Models.Profiles;
using LocumGQLGateway.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocumGQLGateway.Services.Implementations;

public class ShiftTypeService : IShiftTypeService
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public ShiftTypeService(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<ShiftType>> GetAllAsync()
    {
        await using var ctx = _factory.CreateDbContext();
        return await ctx.ShiftTypes.ToListAsync();
    }

    public async Task<ShiftType?> GetByIdAsync(int id)
    {
        await using var ctx = _factory.CreateDbContext();
        return await ctx.ShiftTypes.FindAsync(id);
    }
}