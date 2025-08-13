using LocumGQLGateway.Data;
using LocumGQLGateway.Models.Profiles;
using LocumGQLGateway.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocumGQLGateway.Services.Implementations;

/// <summary>
///     Service implementation for managing <see cref="LocationType" /> entities.
/// </summary>
public class LocationTypeService : ILocationTypeService
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    /// <summary>
    ///     Initializes a new instance of the <see cref="LocationTypeService" /> class.
    /// </summary>
    /// <param name="factory">Database context factory to create <see cref="AppDbContext" /> instances.</param>
    public LocationTypeService(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    /// <summary>
    ///     Retrieves all <see cref="LocationType" /> records asynchronously.
    /// </summary>
    /// <returns>A collection of all <see cref="LocationType" /> entities.</returns>
    public async Task<IEnumerable<LocationType>> GetAllAsync()
    {
        await using var ctx = _factory.CreateDbContext();

        // Retrieve all LocationType entities from the database
        return await ctx.LocationTypes.ToListAsync();
    }

    /// <summary>
    ///     Retrieves a <see cref="LocationType" /> by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="LocationType" />.</param>
    /// <returns>The matching <see cref="LocationType" /> entity if found; otherwise, null.</returns>
    public async Task<LocationType?> GetByIdAsync(int id)
    {
        await using var ctx = _factory.CreateDbContext();

        // Find the LocationType entity by ID
        return await ctx.LocationTypes.FindAsync(id);
    }
}