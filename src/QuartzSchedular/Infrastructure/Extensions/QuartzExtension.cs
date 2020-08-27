using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using QuartzSchedular;
using QuartzSchedular.Infrastructure;
using QuartzSchedular.Infrastructure.Configuration;
using QuartzSchedular.Infrastructure.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class QuartzExtension
    {
        public static IServiceCollection AddQuartzService(this IServiceCollection services,IConfiguration configuration)
        {
            var QuartzSchedularFactoryConfiguration = new ConfigurationFactory(configuration).GetInstance();
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(QuartzSchedularFactoryConfiguration.GetNameValueCollection());
            services.AddSingleton<IJobFactory, CustomJobFactory>();
            services.AddSingleton(schedulerFactory);
            services.AddSingleton<DefaultSchedularListener>();
            services.AddHostedService<QuartzHostedService>();
            return services;
        }
    }
}
