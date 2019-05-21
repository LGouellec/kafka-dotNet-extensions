using System;

namespace kafka_dotNet_extensions_core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple =false, Inherited = false)]
    public class KafkaConfigurationAttribute : Attribute
    {
        public KafkaConfigurationAttribute()
        {
        }

        public string KafkaPropertyName { get; set; }
    }
}
