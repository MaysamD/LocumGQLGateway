namespace JobScheduler.Models;

/// <summary>
///     Represents the configuration settings required for a Service Bus worker.
/// </summary>
public class ServiceBusWorkerConfig
{
    /// <summary>
    ///     Gets or sets the connection string used to connect to the Service Bus namespace.
    /// </summary>
    public string? ConnectionString { get; set; } = "";

    /// <summary>
    ///     Gets or sets the name of the Service Bus queue that the worker will process messages from.
    /// </summary>
    public string QueueName { get; set; } = "";
}