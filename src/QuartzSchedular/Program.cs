using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using QuartzSchedular.Infrastructure.Configuration.Base;
using QuartzSchedular.Jobs;
using QuartzSchedular.Repository;

namespace QuartzSchedular
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<HelloWorldJob>();
                    services.AddSingleton<IUserService, UserService>();
                    services.AddSingleton(new JobSchedule(
                        jobType: typeof(HelloWorldJob),
                        cronExpression: "0/2 * * * * ?", null));
                    services.AddQuartzService(hostContext.Configuration);
                   
                });
    }
}
