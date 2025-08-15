using NotificationScheduler;
using NotificationScheduler.NotificationJobs;
using Quartz;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // Read Service Bus config from appsettings or environment
        var serviceBusConnection = Environment.GetEnvironmentVariable("SERVICEBUS_CONNECTIONSTRING") ??
                                   context.Configuration["ServiceBus:ConnectionString"];

        var queueName = context.Configuration["ServiceBus:QueueName"] ?? "notifications";

        // Register ServiceBusSenderHelper as singleton
        services.AddSingleton(new ServiceBusSenderHelper(serviceBusConnection, queueName));


        var jobConfigs = context.Configuration
            .GetSection("Quartz:Jobs")
            .Get<List<JobConfig>>();

        services.AddQuartz(q =>
        {
            // Job1
            var job1Config = jobConfigs?.Find(j => j.Name == "Job1");
            if (job1Config != null)
            {
                q.AddJob<Job1>(opts =>
                    opts.WithIdentity(job1Config.Name)
                        .WithDescription(job1Config.Description));

                q.AddTrigger(t => t
                    .ForJob(job1Config.Name)
                    .WithIdentity($"{job1Config.Name}Trigger")
                    .WithCronSchedule(job1Config.CronSchedule));
            }

            // Job2
            var job2Config = jobConfigs?.Find(j => j.Name == "Job2");
            if (job2Config != null)
            {
                q.AddJob<Job2>(opts =>
                    opts.WithIdentity(job2Config.Name)
                        .WithDescription(job2Config.Description));

                q.AddTrigger(t => t
                    .ForJob(job2Config.Name)
                    .WithIdentity($"{job2Config.Name}Trigger")
                    .WithCronSchedule(job2Config.CronSchedule));
            }
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

        // Register jobs for DI
        services.AddTransient<Job1>();
        services.AddTransient<Job2>();
    })
    .Build();

await host.RunAsync();