using System.Text.Json;
using Azure.Messaging.ServiceBus;
using LocumApp.Application.DTOs;
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

        // Attach handlers
        processor.ProcessMessageAsync += args => MessageHandlerAsync(args, stoppingToken);
        processor.ProcessErrorAsync += ErrorHandlerAsync;

        await processor.StartProcessingAsync(stoppingToken);

        await Task.Delay(Timeout.Infinite, stoppingToken);

        await processor.StopProcessingAsync();
    }

    private Task ErrorHandlerAsync(ProcessErrorEventArgs args)
    {
        _logger.LogError(args.Exception, "Service Bus error. Entity: {Entity}", args.EntityPath);
        return Task.CompletedTask;    }

    private async Task MessageHandlerAsync(ProcessMessageEventArgs args, CancellationToken stoppingToken)
    {
  
            var json = args.Message.Body.ToString();
            _logger.LogInformation("Received message: {json}", json);

            // Deserialize to NotificationDto
            var notification = JsonSerializer.Deserialize<NotificationDto>(json);
            
            if (notification != null)
            {
                // TODO: Your processing logic here
                _logger.LogInformation(
                    "Processing notification for type {Type}, recipient {Recipient}",
                    notification.Type,
                    notification.Type switch
                    {
                        LocumApp.Domain.Enums.NotificationType.Email => notification.EmailRecipient,
                        LocumApp.Domain.Enums.NotificationType.SMS => notification.SmsRecipient,
                        LocumApp.Domain.Enums.NotificationType.InApp => notification.UserId.ToString(),
                        _ => "Unknown"
                    });
            }

            await args.CompleteMessageAsync(args.Message, stoppingToken);
    }
}