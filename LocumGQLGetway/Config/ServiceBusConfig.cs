namespace LocumGQLGateway.Config;

public class ServiceBusConfig
{
    public string? ConnectionString { get; set; } = string.Empty;
    public string? TopicName { get; set; } = string.Empty;
    public string QueueName { get; set; } = string.Empty;
}