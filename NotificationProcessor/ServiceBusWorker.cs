using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NotificationProcessor;

public class ServiceBusWorker : BackgroundService
{
    private readonly ILogger<ServiceBusWorker> _logger;
    private readonly IConfiguration _configuration;
    private ServiceBusClient _client;
    private ServiceBusProcessor _processor;

    public ServiceBusWorker(ILogger<ServiceBusWorker> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var serviceBusConfig = _configuration.GetSection("ServiceBus");
        string connectionString = serviceBusConfig["ConnectionString"];
        string queueName = serviceBusConfig["QueueName"];

        _client = new ServiceBusClient(connectionString);
        _processor = _client.CreateProcessor(queueName, new ServiceBusProcessorOptions
        {
            AutoCompleteMessages = false,
            MaxConcurrentCalls = 5
        });

        _processor.ProcessMessageAsync += ProcessMessageHandler;
        _processor.ProcessErrorAsync += ErrorHandler;

        _logger.LogInformation("Starting Service Bus processor for queue: {queueName}", queueName);

        await _processor.StartProcessingAsync(stoppingToken);

        // Wait until stopping token is triggered
        await Task.Delay(Timeout.Infinite, stoppingToken);

        _logger.LogInformation("Stopping Service Bus processor...");
        await _processor.StopProcessingAsync();
        await _processor.DisposeAsync();
        await _client.DisposeAsync();
    }

    private async Task ProcessMessageHandler(ProcessMessageEventArgs args)
    {
        string body = args.Message.Body.ToString();
        _logger.LogInformation("Received message: {message}", body);

        // TODO: Add your business logic here
        await ProcessMessage(body);

        // Complete the message so it’s removed from the queue
        await args.CompleteMessageAsync(args.Message);
    }

    private Task ErrorHandler(ProcessErrorEventArgs args)
    {
        _logger.LogError(args.Exception, "Message handler encountered an exception");
        return Task.CompletedTask;
    }

    private Task ProcessMessage(string message)
    {
        // Your processing logic
        _logger.LogInformation("Processing message: {message}", message);
        return Task.CompletedTask;
    }
}