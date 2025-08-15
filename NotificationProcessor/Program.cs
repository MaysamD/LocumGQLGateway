using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotificationProcessor;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        // Add environment variables to override appsettings.json
        config.AddEnvironmentVariables();
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
    })
    .ConfigureServices((context, services) =>
    {
        // Bind ServiceBus config from app settings.json or environment variable
        services.Configure<ServiceBusWorkerConfig>(options =>
        {
            options.ConnectionString = Environment.GetEnvironmentVariable("SERVICEBUS_CONNECTIONSTRING")
                                       ?? context.Configuration["ServiceBus:ConnectionString"];
            options.QueueName = context.Configuration["ServiceBus:QueueName"] ?? "notifications";
        });

        // Register the worker
        services.AddHostedService<ServiceBusWorker>();
    })
    .Build();

await host.RunAsync();