namespace NotificationProcessor.Models;

public class ServiceBusWorkerConfig
{
    public string? ConnectionString { get; set; } = "";
    public string QueueName { get; set; } = "";
}