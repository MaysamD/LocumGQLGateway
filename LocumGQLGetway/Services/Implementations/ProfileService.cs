using LocumGQLGateway.Data;
using LocumGQLGateway.Dtos;
using LocumGQLGateway.Models.Profiles;
using LocumGQLGateway.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;

namespace LocumGQLGateway.Services.Implementations;

/// <summary>
///     Service implementation for managing user profiles including retrieval, updates,
///     and address management.
/// </summary>
public class ProfileService : IProfileService
{
    private readonly IDbContextFactory<AppDbContext> _factory;
    private readonly IStateService _stateService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ProfileService" /> class.
    /// </summary>
    /// <param name="factory">Database context factory for creating <see cref="AppDbContext" /> instances.</param>
    /// <param name="stateService">Service for managing states.</param>
    public ProfileService(IDbContextFactory<AppDbContext> factory, IStateService stateService)
    {
        _factory = factory;
        _stateService = stateService;
    }

    /// <summary>
    ///     Retrieves all profiles including related user, preferences, notification settings, and address data.
    /// </summary>
    /// <returns>A collection of <see cref="Profile" /> entities.</returns>
    public async Task<IEnumerable<Profile>> GetAllAsync()
    {
        await using var ctx = _factory.CreateDbContext();
        return await ctx.Profiles
            .Include(p => p.User!) // Include associated User entity
            .Include(p => p.Preference!.FacilityTypes)
            .Include(p => p.Preference!.JobTypes)
            .Include(p => p.Preference!.ShiftTypes)
            .Include(p => p.Preference!.LocationTypes)
            .Include(p => p.Preference!.States)
            .Include(p => p.ProfileNotificationSettings)
            .Include(p => p.Address)
            .ThenInclude(address => address!.State)
            .ToListAsync();
    }

    /// <summary>
    ///     Retrieves a profile by its associated user ID.
    /// </summary>
    /// <param name="userId">The user ID.</param>
    /// <returns>The matching <see cref="Profile" /> or null if not found.</returns>
    public async Task<Profile?> GetProfileByUserId(int userId)
    {
        await using var ctx = _factory.CreateDbContext();
        return (await GetAllAsync())
            .FirstOrDefault(p => p.UserId == userId);
    }

    /// <summary>
    ///     Updates profile details based on the provided <see cref="ProfileDto" />.
    /// </summary>
    /// <param name="input">The profile data transfer object.</param>
    /// <returns>True if update succeeded; otherwise false.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when profile is not found.</exception>
    public async Task<bool> UpdateAsync(ProfileDto input)
    {
        await using var ctx = _factory.CreateDbContext();
        var profile = await ctx.Profiles
            .FirstOrDefaultAsync(p => p.Id == input.ProfileId);

        if (profile == null)
            throw new KeyNotFoundException($"Profile with ID {input.ProfileId} not found.");

        // Update scalar properties
        profile.FirstName = input.FirstName;
        profile.LastName = input.LastName;
        profile.PhoneNumber = input.PhoneNumber;

        await ctx.SaveChangesAsync();
        return true;
    }

    /// <summary>
    ///     Updates or creates the address associated with a profile.
    /// </summary>
    /// <param name="input">The address data transfer object.</param>
    /// <returns>True if update succeeded; otherwise throws.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when profile is not found.</exception>
    /// <exception cref="DbUpdateException">Thrown on database update failure.</exception>
    public async Task<bool> UpdateProfileAddress(AddressDto input)
    {
        try
        {
            await using var ctx = _factory.CreateDbContext();
            var profile = await ctx.Profiles.Include(profile => profile.Preference!).Include(profile => profile.Address)
                .Include(p => p.Preference!)
                .Include(p => p.Address)
                .ThenInclude(address => address!.State)
                .FirstOrDefaultAsync(p => p.Id == input.ProfileId);

            if (profile == null)
                throw new KeyNotFoundException($"Profile with ID {input.ProfileId} not found.");

            var addressEntity = profile!.Address;

            if (addressEntity is null)
            {
                addressEntity = new Address();
                ctx.Address.Add(addressEntity);
                addressEntity.ProfileId = input.ProfileId;
            }

            addressEntity.Street1 = input.Street1;
            addressEntity.Street2 = input.Street2;
            addressEntity.City = input.City;
            if (input.StateId.HasValue)
                addressEntity.State = await _stateService.GetByIdAsync(input.StateId!.Value);
            addressEntity.PostalCode = input.PostalCode;
            addressEntity.Country = input.Country;
            await ctx.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException ex)
        {
            var innerException = ex.InnerException;
            // Log or inspect innerException.Message for specific DB error
            Console.WriteLine(ex);
            throw;
        }
        catch (Exception ex)
        {
            var innerException = ex.InnerException;
            // Log or inspect innerException.Message for specific DB error
            Console.WriteLine(ex);
            throw;
        }
    }

    /// <summary>
    ///     Retrieves a profile by the user's email address.
    /// </summary>
    /// <param name="email">The email address to search by.</param>
    /// <returns>The matching <see cref="Profile" /> or null if not found.</returns>
    public async Task<Profile?> GetProfileByEmail(string email)
    {
        await using var ctx = _factory.CreateDbContext();
        return (await GetAllAsync())
            .FirstOrDefault(p => p.User!.Email == email);
    }
}