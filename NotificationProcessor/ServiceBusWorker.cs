using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace NotificationProcessor;

public class ServiceBusWorker : BackgroundService
{
    private readonly ServiceBusWorkerConfig _config;
    private readonly ILogger<ServiceBusWorker> _logger;

    public ServiceBusWorker(IOptions<ServiceBusWorkerConfig> options, ILogger<ServiceBusWorker> logger)
    {
        _config = options.Value;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await using var client = new ServiceBusClient(_config.ConnectionString);
        var processor = client.CreateProcessor(_config.QueueName, new ServiceBusProcessorOptions());

        processor.ProcessMessageAsync += async args =>
        {
            var message = args.Message.Body.ToString();
            _logger.LogInformation("Received message: {message}", message);

            // TODO: Your processing logic here

            await args.CompleteMessageAsync(args.Message);
        };

        processor.ProcessErrorAsync += args =>
        {
            _logger.LogError(args.Exception, "Error processing message");
            return Task.CompletedTask;
        };

        await processor.StartProcessingAsync(stoppingToken);

        await Task.Delay(Timeout.Infinite, stoppingToken);

        await processor.StopProcessingAsync();
    }
}