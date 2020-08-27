using System;

namespace QuartzSchedular.Infrastructure.Attributes
{
    public class MappedToPropertyAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
