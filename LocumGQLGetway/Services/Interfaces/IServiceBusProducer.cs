namespace LocumGQLGateway.Services.Interfaces;

public interface IServiceBusProducer
{
    Task SendMessageAsync<T>(T message);
}