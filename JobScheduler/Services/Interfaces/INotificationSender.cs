using LocumApp.Domain.Models.Notifications;

namespace JobScheduler.Services.Interfaces;

public interface INotificationSender
{
    Task SendAsync(Notification notification);
}