using LocumGQLGateway.Models;
using LocumGQLGateway.Services.Interfaces;

namespace LocumGQLGateway.GraphQL.Queries;

/// <summary>
/// GraphQL query resolvers for User-related data.
/// </summary>
public partial class Query
{
    /// <summary>
    /// Retrieves all users with support for projection, filtering, and sorting.
    /// </summary>
    /// <param name="userService">Injected user service.</param>
    /// <returns>A collection of users.</returns>
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IEnumerable<User>> GetUsers([Service] IUserService userService) =>
        userService.GetAllAsync();

    /// <summary>
    /// Retrieves a single user by their unique identifier with support for projection and filtering.
    /// </summary>
    /// <param name="id">User identifier.</param>
    /// <param name="userService">Injected user service.</param>
    /// <returns>A user or null if not found.</returns>
    [UseProjection]
    [UseFiltering]
    public Task<User?> GetUserById(int id, [Service] IUserService userService) =>
        userService.GetByIdAsync(id);
}