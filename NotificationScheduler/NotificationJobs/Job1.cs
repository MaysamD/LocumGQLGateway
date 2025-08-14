using Quartz;

namespace NotificationScheduler.NotificationJobs;

public class Job1 : IJob
{
    private readonly ILogger<Job1> _logger;

    public Job1(ILogger<Job1> logger)
    {
        _logger = logger;
    }

    public Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("Job1 executed at {time}", DateTime.Now);
        // TODO: Add yor logic here
        return Task.CompletedTask;
    }
}