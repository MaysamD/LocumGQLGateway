using LocumApp.Domain.Models.Profiles;
using LocumGQLGateway.Data;
using LocumGQLGateway.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocumGQLGateway.Services.Implementations;

/// <summary>
///     Service implementation for managing <see cref="JobType" /> entities.
/// </summary>
public class JobTypeService : IJobTypeService
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    /// <summary>
    ///     Initializes a new instance of the <see cref="JobTypeService" /> class.
    /// </summary>
    /// <param name="factory">Database context factory to create <see cref="AppDbContext" /> instances.</param>
    public JobTypeService(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    /// <summary>
    ///     Retrieves all <see cref="JobType" /> records asynchronously.
    /// </summary>
    /// <returns>A collection of all <see cref="JobType" /> entities.</returns>
    public async Task<IEnumerable<JobType>> GetAllAsync()
    {
        await using var ctx = _factory.CreateDbContext();

        // Fetch all JobType records from the database
        return await ctx.JobTypes.ToListAsync();
    }

    /// <summary>
    ///     Retrieves a <see cref="JobType" /> by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="JobType" />.</param>
    /// <returns>The matching <see cref="JobType" /> entity if found; otherwise, null.</returns>
    public async Task<JobType?> GetByIdAsync(int id)
    {
        await using var ctx = _factory.CreateDbContext();

        // Find the JobType entity with the specified ID
        return await ctx.JobTypes.FindAsync(id);
    }
}