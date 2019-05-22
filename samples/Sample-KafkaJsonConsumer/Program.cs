using kafka_dotNet_extensions_core;
using kafka_dotNet_extensions_core.Configuration;
using kafka_dotNet_extensions_core.Serializer;
using System;
using System.Threading;

namespace Sample_KafkaJsonConsumer
{
    public class MyObject
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"ID: {ID} | Name : {Name}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => {
                e.Cancel = true;
                cts.Cancel();
            };
            var cancellationToken = cts.Token;

            var builder = new ConsumerBuilder<Confluent.Kafka.Null, MyObject>()
                                    .UseSectionConfiguration("testjson")
                                    .UseOptions(opt =>
                                    {
                                        opt.ErrorHandler = ((_, e) => Console.WriteLine($"Error: {e.Reason}"));
                                        opt.ValueDeserializer = new JsonObjectDeserializer<MyObject>();
                                    });

            using (var consumer = builder.Build())
            {
                try
                {
                    while (true)
                    {
                        try
                        {
                            var consumeResult = consumer.Consume(cancellationToken);
                            Console.WriteLine($"Received message at {consumeResult.TopicPartitionOffset}: {consumeResult.Value}");
                        }
                        catch (Confluent.Kafka.ConsumeException e)
                        {
                            Console.WriteLine($"Consume error: {e.Error.Reason}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Closing consumer.");
                    consumer.Close();
                }
            }
        }
    }
}
