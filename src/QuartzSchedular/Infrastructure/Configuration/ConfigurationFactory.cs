using Microsoft.Extensions.Configuration;
using QuartzSchedular.Infrastructure.Configuration.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuartzSchedular.Infrastructure.Configuration
{
    public class ConfigurationFactory
    {
        private readonly IConfiguration _configuration;

        public ConfigurationFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public QuartzSchedularFactoryConfigurations GetInstance()
        {
            var configType = _configuration.GetValue<string>("StoreType");
            switch (configType.ToLower())
            {
                case "sqlserver":
                    var sqlStoreQuartzSchedularFactoryConfiguration = new SqlStoreQuartzSchedularFactoryConfiguration();
                    _configuration.GetSection("SqlStoreQuartzSchedularFactoryConfiguration").Bind(sqlStoreQuartzSchedularFactoryConfiguration);
                    return sqlStoreQuartzSchedularFactoryConfiguration;
                default:
                    throw new ArgumentException("Invalid config type");
            }
        }
    }
}
