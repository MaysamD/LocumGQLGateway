using LocumGQLGateway.Dtos;
using LocumGQLGateway.Extensions;
using LocumGQLGateway.Models;
using LocumGQLGateway.Services.Interfaces;

namespace LocumGQLGateway.GraphQL.Mutations;

/// <summary>
///     GraphQL mutation resolver class handling user-related mutations.
/// </summary>
public partial class Mutation
{
    /// <summary>
    ///     Adds a new user to the system.
    /// </summary>
    /// <param name="input">User input data transfer object.</param>
    /// <param name="userService">Injected user service to handle business logic.</param>
    /// <returns>The created <see cref="User" /> entity.</returns>
    /// <exception cref="ValidationException">Thrown if input validation fails.</exception>
    public async Task<User> AddUserAsync(AddUserDto input, [Service] IUserService userService)
    {
        // Validate input properties based on data annotations
        input.ValidateDataAnnotations();

        // Delegate to service layer for adding the user
        return await userService.AddAsync(input);
    }

    /// <summary>
    ///     Updates a user's password.
    /// </summary>
    /// <param name="input">Password update DTO containing user and password info.</param>
    /// <param name="userService">Injected user service to handle business logic.</param>
    /// <returns>True if the password update was successful.</returns>
    /// <exception cref="ValidationException">Thrown if input validation fails.</exception>
    public async Task<bool> UpdatePasswordAsync(UpdatePasswordDto input, [Service] IUserService userService)
    {
        // Validate input properties based on data annotations
        input.ValidateDataAnnotations();

        // Delegate to service layer to perform password update
        await userService.UpdatePasswordAsync(input);
        return true;
    }
}