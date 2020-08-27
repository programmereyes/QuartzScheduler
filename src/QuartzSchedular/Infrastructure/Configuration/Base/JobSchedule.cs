using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzSchedular.Infrastructure.Configuration.Base
{
    public class JobSchedule
    {
        public Type JobType { get; private set; }
        public string CronExpression { get; private set; }
        public IDictionary<string, object> JobDataMap { get; private set; }
        public JobSchedule(Type jobType,string cronExpression,Dictionary<string,object> jobDataMap=null)
        {
            JobType = jobType;
            CronExpression = cronExpression;
            JobDataMap = jobDataMap;
        }
    }
}
