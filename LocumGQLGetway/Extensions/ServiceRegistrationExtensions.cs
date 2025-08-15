using LocumGQLGateway.Config;
using LocumGQLGateway.Services;
using LocumGQLGateway.Services.Implementations;
using LocumGQLGateway.Services.Interfaces;
namespace LocumGQLGateway.Extensions;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddLocumServices(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<ServiceBusConfig>(options =>
        {
            options.ConnectionString = Environment.GetEnvironmentVariable("SERVICEBUS_CONNECTIONSTRING")
                                       ?? config["ServiceBus:ConnectionString"];
            options.TopicName = Environment.GetEnvironmentVariable("SERVICEBUS_TOPIC")
                                ?? config["ServiceBus:TopicName"];
        });

        services.AddScoped<ILocationTypeService, LocationTypeService>();
        services.AddScoped<IFacilityTypeService, FacilityTypeService>();
        services.AddScoped<IShiftTypeService, ShiftTypeService>();
        services.AddScoped<IJobTypeService, JobTypeService>();
        services.AddScoped<IStateService, StateService>();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPreferenceService, PreferenceService>();
        services.AddScoped<ICredentialsService, CredentialsService>();
        // Bind Azure Service Bus config
        var configurationSection = config.GetSection("ServiceBus");
        services.Configure<ServiceBusConfig>(configurationSection);

        // Register Service Bus producer
        services.AddSingleton<IServiceBusProducer, ServiceBusProducer>();


        return services;
    }
}