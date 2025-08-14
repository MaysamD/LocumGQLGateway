namespace NotificationScheduler;

public class JobConfig
{
    public required string Name { get; set; }
    public required string CronSchedule { get; set; }
    public required string Description { get; set; }
}