// Extensions/ServiceRegistrationExtensions.cs

using LocumGQLGateway.Services.Implementations;
using LocumGQLGateway.Services.Interfaces;

namespace LocumGQLGateway.Extensions;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddLocumServices(this IServiceCollection services)
    {
        services.AddScoped<ILocationTypeService, LocationTypeService>();
        services.AddScoped<IFacilityTypeService, FacilityTypeService>();
        services.AddScoped<IShiftTypeService, ShiftTypeService>();
        services.AddScoped<IJobTypeService, JobTypeService>();
        services.AddScoped<IStateService, StateService>();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPreferenceService, PreferenceService>();
        services.AddScoped<ICredentialsService, CredentialsService>();


        return services;
    }
}