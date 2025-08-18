using LocumApp.Domain.Models.Notifications;

namespace NotificationProcessor.Services.Interfaces;

public interface INotificationSender
{
    Task SendAsync(Notification notification);
}