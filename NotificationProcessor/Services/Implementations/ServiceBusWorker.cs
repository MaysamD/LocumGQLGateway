using System.Text.Json;
using Azure.Messaging.ServiceBus;
using LocumApp.Domain.Enums;
using LocumApp.Domain.Models.Notifications;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NotificationProcessor.Models;
using NotificationProcessor.Services.Interfaces;

namespace NotificationProcessor.Services.Implementations;

public class ServiceBusWorker : BackgroundService
{
    private readonly ServiceBusWorkerConfig _config;
    private readonly ILogger<ServiceBusWorker> _logger;
    private readonly IEnumerable<INotificationSender> _senders;

    public ServiceBusWorker(IOptions<ServiceBusWorkerConfig> options, ILogger<ServiceBusWorker> logger,
        IEnumerable<INotificationSender> senders)
    {
        _config = options.Value;
        _logger = logger;
        _senders = senders;
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
        return Task.CompletedTask;
    }

    private async Task MessageHandlerAsync(ProcessMessageEventArgs args, CancellationToken stoppingToken)
    {
        var json = args.Message.Body.ToString();
        _logger.LogInformation("Received message: {json}", json);

        // Deserialize to NotificationDto
        var notification = JsonSerializer.Deserialize<Notification>(json);

        if (notification != null)
        {
            _logger.LogInformation(
                "Processing notification for type {Type}, recipient {Recipient}",
                notification.Type,
                notification.Type switch
                {
                    NotificationType.Email => notification.EmailRecipient,
                    NotificationType.SMS => notification.SmsRecipient,
                    NotificationType.InApp => notification.UserId.ToString(),
                    _ => "Unknown"
                });

            var sender = _senders.FirstOrDefault(s =>
                s.GetType().Name.StartsWith(notification.Type.ToString(), StringComparison.OrdinalIgnoreCase));

            if (sender == null)
                throw new InvalidOperationException($"No sender found for type: {notification.Type.ToString()}");

            await sender.SendAsync(notification);
        }

        await args.CompleteMessageAsync(args.Message, stoppingToken);
    }

    private Task SendInAppAsync(Notification notification)
    {
        _logger.LogInformation("Sending in-app notification");
        // TODO: Your processing logic here
        throw new NotImplementedException();
    }

    private Task SendSmsAsync(Notification notification)
    {
        _logger.LogInformation("Sending sms notification");
        // TODO: Your processing logic here
        throw new NotImplementedException();
    }

    private Task SendEmailAsync(Notification notification)
    {
        _logger.LogInformation("Sending email notification");
        // TODO: Your processing logic here
        throw new NotImplementedException();
    }
}