using Microsoft.Extensions.Logging;
using Quartz;
using QuartzSchedular.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuartzSchedular.Jobs
{
    [DisallowConcurrentExecution]
    //[PersistJobDataAfterExecution]
    public class HelloWorldJob : IJob
    {
        private readonly IUserService _userService;
        private readonly ILogger<HelloWorldJob> _logger;

        public HelloWorldJob(ILogger<HelloWorldJob> logger, IUserService userService)
        {
            _userService = userService;
            _logger = logger;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("This is message from Hello World Job");
        }
    }
}
