using LocumApp.Domain.Models.Notifications;
using Microsoft.Extensions.Logging;
using NotificationProcessor.Services.Interfaces;

namespace NotificationProcessor.Services.Implementations;

public class InAppNotificationSender : INotificationSender
{
    private readonly ILogger<InAppNotificationSender> _logger;

    public InAppNotificationSender(ILogger<InAppNotificationSender> logger)
    {
        _logger = logger;
    }

    public Task SendAsync(Notification notification)
    {
        _logger.LogInformation("Sending in-app notification");
        // TODO: Your in-app notification logic here
        throw new NotImplementedException();
    }
}