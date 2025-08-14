using LocumApp.Domain.Models.Profiles;
using LocumGQLGateway.Data;
using LocumGQLGateway.Dtos;
using LocumGQLGateway.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;

namespace LocumGQLGateway.Services.Implementations;

/// <summary>
///     Service implementation for managing user preferences including facility types, job types,
///     location types, shift types, and states associated with a profile.
/// </summary>
public class PreferenceService : IPreferenceService
{
    private readonly IFacilityTypeService _facilityTypeService;
    private readonly IDbContextFactory<AppDbContext> _factory;
    private readonly IJobTypeService _jobTypeService;
    private readonly ILocationTypeService _locationTypeService;
    private readonly IShiftTypeService _shiftTypeService;
    private readonly IStateService _stateService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="PreferenceService" /> class.
    /// </summary>
    /// <param name="factory">Database context factory for creating <see cref="AppDbContext" /> instances.</param>
    /// <param name="facilityTypeService">Service for managing facility types.</param>
    /// <param name="shiftTypeService">Service for managing shift types.</param>
    /// <param name="jobTypeService">Service for managing job types.</param>
    /// <param name="locationTypeService">Service for managing location types.</param>
    /// <param name="stateService">Service for managing states.</param>
    public PreferenceService(
        IDbContextFactory<AppDbContext> factory,
        IFacilityTypeService facilityTypeService,
        IShiftTypeService shiftTypeService,
        IJobTypeService jobTypeService,
        ILocationTypeService locationTypeService,
        IStateService stateService)
    {
        _factory = factory;
        _facilityTypeService = facilityTypeService;
        _shiftTypeService = shiftTypeService;
        _jobTypeService = jobTypeService;
        _locationTypeService = locationTypeService;
        _stateService = stateService;
    }

    /// <summary>
    ///     Retrieves the <see cref="Preference" /> entity for a specific profile, including all related collections.
    /// </summary>
    /// <param name="profileId">The profile identifier.</param>
    /// <returns>The <see cref="Preference" /> entity or null if not found.</returns>
    public async Task<Preference?> GetByProfileIdAsync(int profileId)
    {
        await using var ctx = _factory.CreateDbContext();
        return await ctx.Preferences
            .Include(p => p.FacilityTypes)
            .Include(p => p.ShiftTypes)
            .Include(p => p.JobTypes)
            .Include(p => p.LocationTypes)
            .Include(p => p.States)
            .FirstOrDefaultAsync(p => p.ProfileId == profileId);
    }

    /// <summary>
    ///     Updates the profile preferences based on the provided DTO.
    /// </summary>
    /// <param name="input">The preference data transfer object containing updated IDs for each preference category.</param>
    /// <returns>True if update is successful; otherwise, throws an exception.</returns>
    /// <exception cref="KeyNotFoundException">Thrown when the profile preference entity is not found.</exception>
    /// <exception cref="DbUpdateException">Thrown on database update failure.</exception>
    public async Task<bool> UpdateProfilePreference(PreferenceDto input)
    {
        try
        {
            await using var ctx = _factory.CreateDbContext();
            var preferenceEntity = await ctx.Preferences
                .Include(p => p.FacilityTypes)
                .Include(p => p.ShiftTypes)
                .Include(p => p.JobTypes)
                .Include(p => p.LocationTypes)
                .Include(p => p.States)
                .FirstOrDefaultAsync(p => p.ProfileId == input.ProfileId);

            if (preferenceEntity == null)
                throw new KeyNotFoundException($"Profile with ID {input.ProfileId} not found.");

            await UpdateFacilityType(input, preferenceEntity, ctx);
            await UpdateJobType(input, preferenceEntity, ctx);
            await UpdateLocationType(input, preferenceEntity, ctx);
            await UpdateState(input, preferenceEntity, ctx);
            await UpdateShiftType(input, preferenceEntity, ctx);

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
    ///     Synchronizes the LocationTypes collection on the preference entity with the provided input IDs.
    ///     Removes unselected and adds new location types.
    /// </summary>
    private static async Task UpdateLocationType(PreferenceDto input, Preference preferenceEntity, AppDbContext ctx)
    {
        // ---- Remove ones that no longer exist ----
        var toRemove = preferenceEntity.LocationTypes
            .Where(lt => !input.LocationTypeIds.Contains(lt.Id))
            .ToList();
        foreach (var lt in toRemove)
            preferenceEntity.LocationTypes.Remove(lt);

        // ---- Add new ones that aren't already there ----
        var existingIds = preferenceEntity.LocationTypes
            .Select(lt => lt.Id)
            .ToHashSet();

        var toAddIds = input.LocationTypeIds
            .Where(id => !existingIds.Contains(id))
            .ToList();

        foreach (var id in toAddIds)
        {
            var locationType = await ctx.LocationTypes.FindAsync(id);
            if (locationType != null)
                preferenceEntity.LocationTypes.Add(locationType);
        }
    }

    /// <summary>
    ///     Synchronizes the States collection on the preference entity with the provided input IDs.
    ///     Removes unselected and adds new states.
    /// </summary>
    private static async Task UpdateState(PreferenceDto input, Preference preferenceEntity, AppDbContext ctx)
    {
        // ---- Remove ones that no longer exist ----
        var toRemove = preferenceEntity.States
            .Where(s => !input.StateIds.Contains(s.Id!))
            .ToList();
        foreach (var s in toRemove)
            preferenceEntity.States.Remove(s);

        // ---- Add new ones that aren't already there ----
        var existingIds = preferenceEntity.States
            .Select(s => s.Id)
            .ToHashSet();

        var toAddIds = input.StateIds
            .Where(id => !existingIds.Contains(id))
            .ToList();

        foreach (var id in toAddIds)
        {
            var state = await ctx.States.FindAsync(id);
            if (state != null)
                preferenceEntity.States.Add(state);
        }
    }

    /// <summary>
    ///     Synchronizes the ShiftTypes collection on the preference entity with the provided input IDs.
    ///     Removes unselected and adds new shift types.
    /// </summary>
    private static async Task UpdateShiftType(PreferenceDto input, Preference preferenceEntity, AppDbContext ctx)
    {
        // ---- Remove ones that no longer exist ----
        var toRemove = preferenceEntity.ShiftTypes
            .Where(st => !input.ShiftTypeIds.Contains(st.Id!))
            .ToList();
        foreach (var st in toRemove)
            preferenceEntity.ShiftTypes.Remove(st);

        // ---- Add new ones that aren't already there ----
        var existingIds = preferenceEntity.ShiftTypes
            .Select(st => st.Id)
            .ToHashSet();

        var toAddIds = input.ShiftTypeIds
            .Where(id => !existingIds.Contains(id))
            .ToList();

        foreach (var id in toAddIds)
        {
            var shiftType = await ctx.ShiftTypes.FindAsync(id);
            if (shiftType != null)
                preferenceEntity.ShiftTypes.Add(shiftType);
        }
    }

    /// <summary>
    ///     Synchronizes the FacilityTypes collection on the preference entity with the provided input IDs.
    ///     Removes unselected and adds new facility types.
    /// </summary>
    private static async Task UpdateFacilityType(PreferenceDto input, Preference preferenceEntity, AppDbContext ctx)
    {
        // ---- Remove ones that no longer exist ----
        var toRemove = preferenceEntity.FacilityTypes
            .Where(ft => !input.FacilityTypeIds.Contains(ft.Id!))
            .ToList();
        foreach (var ft in toRemove) preferenceEntity.FacilityTypes.Remove(ft);

        // ---- Add new ones that aren't already there ----
        var existingIds = preferenceEntity.FacilityTypes.Select(ft => ft.Id).ToHashSet();

        var toAddIds = input.FacilityTypeIds
            .Where(id => !existingIds.Contains(id))
            .ToList();

        foreach (var id in toAddIds)
        {
            var facilityType = await ctx.FacilityTypes.FindAsync(id);
            if (facilityType != null) preferenceEntity.FacilityTypes.Add(facilityType);
        }
    }

    /// <summary>
    ///     Synchronizes the JobTypes collection on the preference entity with the provided input IDs.
    ///     Removes unselected and adds new job types.
    /// </summary>
    private static async Task UpdateJobType(PreferenceDto input, Preference preferenceEntity, AppDbContext ctx)
    {
        // ---- Remove ones that no longer exist ----
        var toRemove = preferenceEntity.JobTypes
            .Where(jt => !input.JobTypeIds.Contains(jt.Id!))
            .ToList();
        foreach (var jt in toRemove)
            preferenceEntity.JobTypes.Remove(jt);

        // ---- Add new ones that aren't already there ----
        var existingIds = preferenceEntity.JobTypes
            .Select(jt => jt.Id)
            .ToHashSet();

        var toAddIds = input.JobTypeIds
            .Where(id => !existingIds.Contains(id))
            .ToList();

        foreach (var id in toAddIds)
        {
            var jobType = await ctx.JobTypes.FindAsync(id);
            if (jobType != null)
                preferenceEntity.JobTypes.Add(jobType);
        }
    }
}