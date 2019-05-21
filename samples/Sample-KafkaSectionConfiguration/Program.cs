using kafka_dotNet_extensions_core;
using System.Configuration;

namespace Sample_KafkaSectionConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;
            var section = config.GetSection("KafkaSection") as KafkaSection;
        }
    }
}
