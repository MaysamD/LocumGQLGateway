using Quartz;

namespace NotificationScheduler.NotificationJobs;

public class Job1 : IJob
{
    private readonly ILogger<Job1> _logger;
    private readonly ServiceBusSenderHelper _senderHelper;

    public Job1(ILogger<Job1> logger, ServiceBusSenderHelper senderHelper)
    {
        _logger = logger;
        _senderHelper = senderHelper;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("Job1 executed at {time}", DateTime.Now);

        // TODO: Add yor logic here
        var msg = $"Notification triggered at {DateTime.Now}";
        _logger.LogInformation(msg);

        // Send to Service Bus
        await _senderHelper.SendMessageAsync(msg);
    }
}