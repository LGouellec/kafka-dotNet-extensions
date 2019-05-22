using kafka_dotNet_extensions_core;
using kafka_dotNet_extensions_core.Configuration;
using kafka_dotNet_extensions_core.Serializer;
using System;

namespace Sample_KafkaJsonProducer
{
    public class MyObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            var builder = new ProducerBuilder<Confluent.Kafka.Null, MyObject>()
                                .UseSectionConfiguration()
                                .UseOptions(opt =>
                                {
                                    opt.ErrorHandler = (_, e) => { Console.WriteLine(e); };
                                    opt.ValueSerializer = new JsonObjectSerializer<MyObject>();
                                });

            using (var producer = builder.Build())
            {
                string text = null;

                while (true)
                {
                    text = Console.ReadLine();
                    if (text != "exit")
                        producer.ProduceAsync("testjson",
                            new Confluent.Kafka.Message<Confluent.Kafka.Null, MyObject>()
                            {
                                Key = null,
                                Value = new MyObject { ID = ++i, Name = $"Message: {text}"}
                            });
                    else
                        break;
                }

                producer.Flush();
            }
        }
    }
}
