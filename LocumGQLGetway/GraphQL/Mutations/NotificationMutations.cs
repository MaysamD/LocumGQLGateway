using LocumGQLGateway.Services;
using System.Threading.Tasks;
using LocumApp.Application.DTOs;
using LocumApp.Domain.Models.Notifications;
using LocumGQLGateway.Extensions;
using LocumGQLGateway.Services.Implementations;
using LocumGQLGateway.Services.Interfaces;

namespace LocumGQLGateway.GraphQL.Mutations;

public partial class Mutation
{

    public async Task<string> SendNotificationAsync([Service] IServiceBusProducer serviceBusProducer, NotificationDto message)
    {
        message.ValidateDataAnnotations();
        // Here you can format your Kafka message (JSON, etc.)
        await serviceBusProducer.SendMessageAsync(message);

        return "Message queued in Kafka";
    }
}