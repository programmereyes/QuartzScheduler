using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Logging;
using Quartz.Spi;
using QuartzSchedular.Infrastructure;
using QuartzSchedular.Infrastructure.Configuration.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzSchedular
{
    public class QuartzHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<JobSchedule> _jobSchedules;
        private readonly ILogger<QuartzHostedService> _logger;

        public IScheduler Scheduler { get; private set; }

        public QuartzHostedService(IServiceProvider serviceProvider,ISchedulerFactory schedulerFactory, IJobFactory jobFactory, IEnumerable<JobSchedule> jobSchedules, ILogger<QuartzHostedService> logger)
        {
            _serviceProvider = serviceProvider;
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
            _jobSchedules = jobSchedules;
            _logger = logger;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.ListenerManager.AddSchedulerListener(_serviceProvider.GetRequiredService<DefaultSchedularListener>());
            Scheduler.JobFactory = _jobFactory;
            foreach (var schedule in _jobSchedules)
            {
                IJobDetail jobDetail = CreateJob(schedule);
                if (await Scheduler.CheckExists(jobDetail.Key, cancellationToken))
                {
                    bool result = await Scheduler.DeleteJob(jobDetail.Key, cancellationToken);
                    if (!result)
                    {
                        throw new ApplicationException("Unable to remove the job");
                    }
                }
                ITrigger jobTrigger = CreateTrigger(schedule);
                _ = await Scheduler.ScheduleJob(jobDetail, jobTrigger, cancellationToken);
                _logger.LogInformation($"{schedule.JobType.FullName} is Scheduled");
            }
            await Scheduler.Start(cancellationToken);
            _logger.LogInformation($"Schedular is stated");
        }

        private ITrigger CreateTrigger(JobSchedule schedule)
        {
            return TriggerBuilder.Create()
                  .WithIdentity($"{schedule.JobType.FullName}.trigger")
                  .WithCronSchedule(schedule.CronExpression).WithDescription(schedule.CronExpression).Build();
        }

        private IJobDetail CreateJob(JobSchedule schedule)
        {
            var jobType = schedule.JobType;
            var jobMapData = schedule.JobDataMap;
            var jobBuilder = JobBuilder.Create(jobType)
                                       .WithIdentity(jobType.FullName)
                                       .WithDescription(jobType.Name);
            if (jobMapData != null)
            {
                jobBuilder.SetJobData(new JobDataMap(jobMapData));
            }
            return jobBuilder.Build();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Scheduler.ListenerManager.RemoveSchedulerListener(_serviceProvider.GetRequiredService<DefaultSchedularListener>());
            await Scheduler.Shutdown(cancellationToken);
        }
    }
}
