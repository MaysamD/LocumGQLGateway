using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Extensions;

public static class ValidationExtensions
{
    /// <summary>
    /// Helper method to run validation and execute a service call, handling exceptions uniformly.
    /// </summary>
    public static async Task<T> ExecuteWithValidationAsync<T>(this object input, Func<Task<T>> serviceCall)
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
            Console.WriteLine(vex);
            // Here you can log or transform validation errors before rethrowing
            throw new GraphQLException($"Validation failed: {vex.Message}", vex);
        }
        catch (Exception ex)
        {
            // Log or handle unexpected exceptions here
            Console.WriteLine(ex);
            throw new GraphQLException("An unexpected error occurred.", ex);
        }
    }
    public static void ValidateDataAnnotations(this object model)
    {
        var validationContext = new ValidationContext(model);
        var validationResults = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(
            model, validationContext, validationResults, true);

        if (!isValid)
        {
            var errors = validationResults.Select(r => r.ErrorMessage ?? "Validation error");
            throw new GraphQLException(errors.Select(e => new Error(e)));
        }
    }
}