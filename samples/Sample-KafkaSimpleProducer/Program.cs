using kafka_dotNet_extensions_core;
using kafka_dotNet_extensions_core.Configuration;
using System;

namespace Sample_KafkaSimpleProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ProducerBuilder<Confluent.Kafka.Null, string>().UseSectionConfiguration();
            using (var producer = builder.Build())
            {
                string text = null;

                while (true)
                {
                    text = Console.ReadLine();
                    if (text != "exit")
                        producer.ProduceAsync("test", new Confluent.Kafka.Message<Confluent.Kafka.Null, string>() { Key = null, Value = text });
                    else
                        break;
                }

                producer.Flush();
            }
        }
    }
}
