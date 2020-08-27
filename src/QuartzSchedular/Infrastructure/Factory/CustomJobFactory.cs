using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzSchedular.Infrastructure.Factory
{
    public class CustomJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CustomJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var jobType = bundle.JobDetail.JobType;
            return _serviceProvider.GetRequiredService(jobType) as IJob;
        }

        public void ReturnJob(IJob job)
        {

        }
    }
}
