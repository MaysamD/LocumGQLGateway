using System.Text.Json;
using Azure.Messaging.ServiceBus;
using LocumGQLGateway.Config;
using LocumGQLGateway.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace LocumGQLGateway.Services;

public class ServiceBusProducer : IServiceBusProducer
{
    private readonly ServiceBusClient _client;
    private readonly string? _connectionString;
    private readonly ILogger<ServiceBusProducer> _logger;
    private readonly string? _topicName;

    public ServiceBusProducer(IOptions<ServiceBusConfig> config, ILogger<ServiceBusProducer> logger)
    {
        _logger = logger;
        _topicName = config.Value.TopicName;

        _connectionString = config.Value.ConnectionString;
        _client = new ServiceBusClient(_connectionString);
    }

    /// <summary>
    ///     Send any object as JSON to the Service Bus topic
    /// </summary>
    public async Task SendMessageAsync<T>(T message)
    {
        try
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var sender = _client.CreateSender(_topicName);

            // Serialize object to JSON
            var jsonBody = JsonSerializer.Serialize(message);

            var serviceBusMessage = new ServiceBusMessage(jsonBody);

            await sender.SendMessageAsync(serviceBusMessage);

            _logger.LogInformation("✅ Message sent to Service Bus topic {Topic}", _topicName);
        }
        catch (ServiceBusException sbEx)
        {
            _logger.LogError(sbEx, "❌ Service Bus error while sending message.");
            throw; // optionally rethrow if you want upstream handling
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "❌ Unexpected error while sending message to Service Bus.");
            throw;
        }
    }
}