using Quartz;

namespace NotificationScheduler.NotificationJobs;

public class Job2 : IJob
{
    private readonly ILogger<Job2> _logger;

    public Job2(ILogger<Job2> logger)
    {
        _logger = logger;
    }

    public Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("Job2 executed at {time}", DateTime.Now);
        // TODO: Add yor logic here
        return Task.CompletedTask;
    }
}