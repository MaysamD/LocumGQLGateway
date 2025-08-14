using LocumApp.Domain.Models.Profiles;
using LocumGQLGateway.Data;
using LocumGQLGateway.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocumGQLGateway.Services.Implementations;

/// <summary>
///     Service implementation for managing FacilityType entities.
/// </summary>
public class FacilityTypeService : IFacilityTypeService
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    /// <summary>
    ///     Initializes a new instance of the <see cref="FacilityTypeService" /> class.
    /// </summary>
    /// <param name="factory">Database context factory to create DbContext instances.</param>
    public FacilityTypeService(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    /// <summary>
    ///     Retrieves all FacilityType records asynchronously.
    /// </summary>
    /// <returns>A collection of all <see cref="FacilityType" /> entities.</returns>
    public async Task<IEnumerable<FacilityType>> GetAllAsync()
    {
        await using var ctx = _factory.CreateDbContext();

        // Fetch all FacilityType records from the database
        return await ctx.FacilityTypes.ToListAsync();
    }

    /// <summary>
    ///     Retrieves a FacilityType by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the FacilityType.</param>
    /// <returns>The matching <see cref="FacilityType" /> entity if found; otherwise, null.</returns>
    public async Task<FacilityType?> GetByIdAsync(int id)
    {
        await using var ctx = _factory.CreateDbContext();

        // Find the FacilityType entity with the specified ID
        return await ctx.FacilityTypes.FindAsync(id);
    }
}