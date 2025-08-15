using Azure.Messaging.ServiceBus;

namespace NotificationScheduler;

public class ServiceBusSenderHelper
{
    private readonly ServiceBusClient _client;
    private readonly string _queueName;

    public ServiceBusSenderHelper(string connectionString, string queueName)
    {
        _client = new ServiceBusClient(connectionString);
        _queueName = queueName;
    }

    public async Task SendMessageAsync(string message)
    {
        var sender = _client.CreateSender(_queueName);
        await sender.SendMessageAsync(new ServiceBusMessage(message));
    }
}