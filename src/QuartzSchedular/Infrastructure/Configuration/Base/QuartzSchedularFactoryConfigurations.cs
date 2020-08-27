using QuartzSchedular.Infrastructure.Attributes;
using System;
using System.Collections.Specialized;
using System.Reflection;

namespace QuartzSchedular.Infrastructure.Configuration.Base
{
    public abstract class QuartzSchedularFactoryConfigurations
    {
        [MappedToProperty(Name = "quartz.scheduler.instanceName")]
        public virtual string SchedularName { get; set; } = "DefaultSchedular";

        [MappedToProperty(Name = "quartz.scheduler.instanceId")]
        public virtual string SchedularId { get; set; } = "AUTO";

        [MappedToProperty(Name = "quartz.jobStore.type")]
        public virtual string JobStoreType { get; set; }

        [MappedToProperty(Name = "quartz.threadPool.type")]
        public virtual string ThreadPoolType { get; set; }

        public NameValueCollection GetNameValueCollection()
        {
            var nameValueCollection = new NameValueCollection();
            foreach (var property in this.GetType().GetProperties())
            {
                var mappedToProperty = property.GetCustomAttribute<MappedToPropertyAttribute>();
                if (mappedToProperty != null)
                {
                    nameValueCollection.Add(mappedToProperty.Name, Convert.ToString(property.GetValue(this)));
                }
            }
            return nameValueCollection;
        }

        [MappedToProperty(Name = "quartz.serializer.type")]
        public virtual string SerailizationType { get; set; }

        [MappedToProperty(Name = "quartz.jobStore.useProperties")]
        public virtual string UseProperties { get; set; }

        [MappedToProperty(Name = "quartz.jobStore.dataSource")]
        public virtual string DataSourceType { get; set; }

        [MappedToProperty(Name = "quartz.jobStore.tablePrefix")]
        public virtual string TablePrefix { get; set; }

        [MappedToProperty(Name = "quartz.jobStore.clustered")]
        public virtual string IsClustered { get; set; }

        [MappedToProperty(Name = "quartz.jobStore.lockHandler.type")]
        public virtual string JobStoreLockHandler { get; set; }

        [MappedToProperty(Name = "quartz.jobStore.driverDelegateType")]
        public virtual string JobStoreDriverDelegateType { get; set; }

        [MappedToProperty(Name = "quartz.dataSource.default.connectionString")]
        public virtual string JobStoreConnectionString { get; set; }

        [MappedToProperty(Name = "quartz.dataSource.default.provider")]
        public virtual string Provider { get; set; }
    }
}
