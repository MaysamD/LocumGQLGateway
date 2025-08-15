namespace NotificationProcessor;

public class ServiceBusWorkerConfig
{
    public string ConnectionString { get; set; } = "";
    public string QueueName { get; set; } = "";
}