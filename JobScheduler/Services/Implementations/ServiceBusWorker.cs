using System.Text.Json;
using Azure.Messaging.ServiceBus;
using JobScheduler.Models;
using JobScheduler.Services.Interfaces;
using LocumApp.Domain.Enums;
using LocumApp.Domain.Models.Notifications;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace JobScheduler.Services.Implementations;

/// <summary>
///     A background worker that listens to an Azure Service Bus queue and processes incoming notifications.
/// </summary>
public class ServiceBusWorker : BackgroundService
{
    private readonly ServiceBusWorkerConfig _config;
    private readonly ILogger<ServiceBusWorker> _logger;
    private readonly IEnumerable<INotificationSender> _senders;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ServiceBusWorker" /> class.
    /// </summary>
    /// <param name="options">The Service Bus worker configuration options.</param>
    /// <param name="logger">The logger instance for logging messages.</param>
    /// <param name="senders">The collection of notification senders (Email, SMS, InApp).</param>
    public ServiceBusWorker(IOptions<ServiceBusWorkerConfig> options, ILogger<ServiceBusWorker> logger,
        IEnumerable<INotificationSender> senders)
    {
        _config = options.Value;
        _logger = logger;
        _senders = senders;
    }

    /// <summary>
    ///     Executes the background service, listening to the Service Bus queue and processing messages.
    /// </summary>
    /// <param name="stoppingToken">Token to signal shutdown of the service.</param>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await using var client = new ServiceBusClient(_config.ConnectionString);
        var processor = client.CreateProcessor(_config.QueueName, new ServiceBusProcessorOptions());

        // Attach handlers
        processor.ProcessMessageAsync += args => HandleMessageAsync(args, stoppingToken);
        processor.ProcessErrorAsync += HandleErrorAsync;

        await processor.StartProcessingAsync(stoppingToken);

        // Keep the service running until cancellation
        await Task.Delay(Timeout.Infinite, stoppingToken);

        await processor.StopProcessingAsync();
    }

    /// <summary>
    ///     Handles Service Bus errors by logging them.
    /// </summary>
    /// <param name="args">The error event arguments.</param>
    /// <returns>A completed task.</returns>
    private Task HandleErrorAsync(ProcessErrorEventArgs args)
    {
        _logger.LogError(args.Exception, "Service Bus error. Entity: {Entity}", args.EntityPath);
        return Task.CompletedTask;
    }

    /// <summary>
    ///     Processes a Service Bus message, deserializes it to a <see cref="Notification" />, and routes it to the appropriate
    ///     sender.
    /// </summary>
    /// <param name="args">The message event arguments.</param>
    /// <param name="stoppingToken">Token to signal cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="InvalidOperationException">Thrown if no matching sender is found for the notification type.</exception>
    private async Task HandleMessageAsync(ProcessMessageEventArgs args, CancellationToken stoppingToken)
    {
        var json = args.Message.Body.ToString();
        _logger.LogInformation("Received message: {json}", json);

        // Deserialize message to Notification
        var notification = JsonSerializer.Deserialize<Notification>(json);
        if (notification == null)
        {
            _logger.LogWarning("Received invalid notification message: {json}", json);
            await args.CompleteMessageAsync(args.Message, stoppingToken);
            return;
        }

        // Log notification details
        _logger.LogInformation(
            "Processing notification for type {Type}, recipient {Recipient}",
            notification.Type,
            GetRecipientInfo(notification));

        // Find the appropriate sender based on notification type
        var sender = _senders.FirstOrDefault(s =>
            s.GetType().Name.StartsWith(notification.Type.ToString(), StringComparison.OrdinalIgnoreCase));

        if (sender == null)
            throw new InvalidOperationException($"No sender found for notification type: {notification.Type}");

        await sender.SendAsync(notification);

        // Mark the message as completed
        await args.CompleteMessageAsync(args.Message, stoppingToken);
    }

    /// <summary>
    ///     Returns a string representation of the notification recipient based on its type.
    /// </summary>
    /// <param name="notification">The notification object.</param>
    /// <returns>A string representing the recipient.</returns>
    private static string? GetRecipientInfo(Notification notification)
    {
        return notification.Type switch
        {
            NotificationType.Email => notification.EmailRecipient,
            NotificationType.SMS => notification.SmsRecipient,
            NotificationType.InApp => notification.UserId.ToString(),
            _ => "Unknown"
        };
    }
}