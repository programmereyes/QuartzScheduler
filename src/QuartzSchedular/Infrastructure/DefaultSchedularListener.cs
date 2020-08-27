using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzSchedular.Infrastructure
{
    public class DefaultSchedularListener : ISchedulerListener
    {
        private readonly ILogger<DefaultSchedularListener> _logger;

        public DefaultSchedularListener(ILogger<DefaultSchedularListener> logger)
        {
            _logger = logger;
        }
        public  Task JobAdded(IJobDetail jobDetail, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Job Added:{jobDetail.Key}");
            return Task.CompletedTask;
        }

        public Task JobDeleted(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Job Deleted:{jobKey}");
            return Task.CompletedTask;
        }

        public Task JobInterrupted(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Job Interrupted:{jobKey}");
            return Task.CompletedTask;
        }

        public Task JobPaused(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Job Paused:{jobKey}");
            return Task.CompletedTask;
        }

        public Task JobResumed(JobKey jobKey, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Job Resumed:{jobKey}");
            return Task.CompletedTask;
        }

        public Task JobScheduled(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Job Scheduled:{trigger.JobKey}");
            return Task.CompletedTask;
        }

        public Task JobsPaused(string jobGroup, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Jobs Paused:{jobGroup}");
            return Task.CompletedTask;
        }

        public Task JobsResumed(string jobGroup, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Jobs Resumed:{jobGroup}");
            return Task.CompletedTask;
        }

        public Task JobUnscheduled(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Jobs Unscheduled:{triggerKey.Group}");
            return Task.CompletedTask;
        }

        public Task SchedulerError(string msg, SchedulerException cause, CancellationToken cancellationToken = default)
        {
            _logger.LogError($"Schedule Error Msg:{msg},Cause:{cause.StackTrace}");
            return Task.CompletedTask;
        }

        public Task SchedulerInStandbyMode(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Scheduler In Standby Mode");
            return Task.CompletedTask;
        }

        public Task SchedulerShutdown(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Scheduler Shutdown");
            return Task.CompletedTask;
        }

        public Task SchedulerShuttingdown(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Scheduler Shutting down");
            return Task.CompletedTask;
        }

        public Task SchedulerStarted(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Scheduler Started");
            return Task.CompletedTask;
        }

        public Task SchedulerStarting(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Scheduler Starting");
            return Task.CompletedTask;
        }

        public Task SchedulingDataCleared(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Scheduling Data Cleared");
            return Task.CompletedTask;
        }

        public Task TriggerFinalized(ITrigger trigger, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Trigger Finalized ${trigger.JobKey}");
            return Task.CompletedTask;
        }

        public Task TriggerPaused(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Trigger Paused ${triggerKey}");
            return Task.CompletedTask;
        }

        public Task TriggerResumed(TriggerKey triggerKey, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Trigger Resumed ${triggerKey}");
            return Task.CompletedTask;
        }

        public Task TriggersPaused(string triggerGroup, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Triggers Paused ${triggerGroup}");
            return Task.CompletedTask;
        }

        public Task TriggersResumed(string triggerGroup, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation($"Triggers Resumed ${triggerGroup}");
            return Task.CompletedTask;
        }
    }
}
