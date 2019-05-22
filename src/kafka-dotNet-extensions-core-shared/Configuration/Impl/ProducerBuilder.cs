using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;

namespace kafka_dotNet_extensions_core.Configuration
{
    public class ProducerBuilder<TKey, TValue> : AbstractBuilder
    {
        public override IBuilder UseConsumerProperties(ConsumerProperties properties)
        {
            return this;
        }

        public override IBuilder UseProducerProperties(ProducerProperties properties)
        {
            ApplyParameters(properties);
            return this;
        }

        public IProducer<TKey, TValue> Build()
        {
            Confluent.Kafka.IProducer<TKey, TValue> producer = null;
            if (_brokerList.Count == 0)
                throw new InvalidOperationException($"One broker must be added to build a consumer. Use the {nameof(AddBroker)} method to add a broker!");

            _configuration["bootstrap.servers"] = String.Join(", ", _brokerList.ToArray());
            var builder = new Confluent.Kafka.ProducerBuilder<TKey, TValue>(_configuration.Select(kp => new KeyValuePair<string, string>(kp.Key, kp.Value.ToString())).AsEnumerable());
            // TODO : Seriazlier
            producer = builder.Build();

            return producer;
        }
    }
}
