using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Extensions;

public class ValidationExtention
{
    /// <summary>
    /// Helper method to run validation and execute a service call, handling exceptions uniformly.
    /// </summary>
    private static async Task<T> ExecuteWithValidationAsync<T>(object input, Func<Task<T>> serviceCall)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));

        try
        {
            // Validate input with extension method, throws ValidationException on failure
            input.ValidateDataAnnotations();

            // Execute service logic
            return await serviceCall();
        }
        catch (ValidationException vex)
        {
            // Here you can log or transform validation errors before rethrowing
            throw new GraphQLException($"Validation failed: {vex.Message}", vex);
        }
        catch (Exception ex)
        {
            // Log or handle unexpected exceptions here
            throw new GraphQLException("An unexpected error occurred.", ex);
        }
    }
}