using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kafka_dotNet_extensions_core.Configuration
{
    public class ConsumerBuilder<TKey, TValue> : AbstractBuilder
    {
        public ConsumerBuilder()
        {
            _subscribeOnBuild = true;
        }

        public override IBuilder UseConsumerProperties(ConsumerProperties properties)
        {
            ApplyParameters(properties);
            return this;
        }

        public override IBuilder UseProducerProperties(ProducerProperties properties)
        {
            return this;
        }

        public IConsumer<TKey, TValue> Build()
        {
            Confluent.Kafka.IConsumer<TKey, TValue> consumer = null;

            try
            {
                if (_brokerList.Count == 0)
                    throw new InvalidOperationException($"One broker must be added to build a consumer. Use the {nameof(AddBroker)} method to add a broker!");

                _configuration["bootstrap.servers"] = String.Join(", ", _brokerList.ToArray());
                var builder = new Confluent.Kafka.ConsumerBuilder<TKey, TValue>(_configuration.Select(kp => new KeyValuePair<string, string>(kp.Key, kp.Value.ToString())).AsEnumerable());
                // TODO : Seriazlier
                consumer = builder.Build();

                return consumer;
            }
            finally
            {
                if (_subscribeOnBuild)
                    consumer.Subscribe(_topics);
            }
        }
    }
}
