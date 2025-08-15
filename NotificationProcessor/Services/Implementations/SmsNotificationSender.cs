using LocumApp.Domain.Models.Notifications;
using Microsoft.Extensions.Logging;
using NotificationProcessor.Services.Interfaces;

namespace NotificationProcessor.Services.Implementations;

public class SmsNotificationSender : INotificationSender
{
    private readonly ILogger<SmsNotificationSender> _logger;

    public SmsNotificationSender(ILogger<SmsNotificationSender> logger)
    {
        _logger = logger;
    }

    public Task SendAsync(Notification notification)
    {
        _logger.LogInformation("Sending SMS notification");
        // TODO: Your SMS notification logic here
        throw new NotImplementedException();
    }
}