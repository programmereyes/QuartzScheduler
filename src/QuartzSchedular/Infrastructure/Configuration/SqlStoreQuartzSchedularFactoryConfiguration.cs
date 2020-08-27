using QuartzSchedular.Infrastructure.Configuration.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzSchedular.Infrastructure.Configuration
{
    public class SqlStoreQuartzSchedularFactoryConfiguration : QuartzSchedularFactoryConfigurations
    {

        public override string SchedularName { get => base.SchedularName; set => base.SchedularName = value; }
        public override string SchedularId { get => base.SchedularId; set => base.SchedularId = value; }
        public override string SerailizationType { get => base.SerailizationType; set => base.SerailizationType = value; }
        public override string IsClustered { get => base.IsClustered; set => base.IsClustered = value; }
        public override string TablePrefix { get => base.TablePrefix; set => base.TablePrefix = value; }
        public override string JobStoreConnectionString { get => base.JobStoreConnectionString; set => base.JobStoreConnectionString = value; }
        public override string JobStoreType { get => "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz"; }
        public override string ThreadPoolType { get => "Quartz.Simpl.SimpleThreadPool, Quartz"; }
        public override string UseProperties { get => "true"; }
        public override string DataSourceType { get => "default"; }
        public override string Provider { get => "SqlServer"; }
        public override string JobStoreLockHandler { get => "Quartz.Impl.AdoJobStore.UpdateLockRowSemaphore, Quartz"; }
        public override string JobStoreDriverDelegateType { get => "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz"; }

    }
}
