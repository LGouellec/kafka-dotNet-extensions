using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kafka_dotNet_extensions_core.Configuration
{
    public class ConsumerBuilder<TKey, TValue> : AbstractBuilder<TKey, TValue>
    {
        private readonly ConsumerOptions<TKey, TValue> _options = new ConsumerOptions<TKey, TValue>();

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
                SetHandlers(builder);

                consumer = builder.Build();

                return consumer;
            }
            finally
            {
                if (_subscribeOnBuild)
                    consumer.Subscribe(_topics);
            }
        }

        public ConsumerBuilder<TKey, TValue> UseOptions(Action<ConsumerOptions<TKey, TValue>> action)
        {
            action(_options);
            return this;
        }

        private void SetHandlers(Confluent.Kafka.ConsumerBuilder<TKey, TValue> builder)
        {
            if (_options.ErrorHandler != null)
                builder.SetErrorHandler(_options.ErrorHandler);

            if (_options.KeyDeserializer != null)
                builder.SetKeyDeserializer(_options.KeyDeserializer);

            if (_options.ValueDeserializer != null)
                builder.SetValueDeserializer(_options.ValueDeserializer);

            if (_options.LogHandler != null)
                builder.SetLogHandler(_options.LogHandler);

            if (_options.OffsetsCommittedHandler != null)
                builder.SetOffsetsCommittedHandler(_options.OffsetsCommittedHandler);

            if (_options.PartitionAssignmentHandler != null)
                builder.SetPartitionsAssignedHandler(_options.PartitionAssignmentHandler);

            if (_options.PartitionsRevokedHandler != null)
                builder.SetPartitionsRevokedHandler(_options.PartitionsRevokedHandler);

            if (_options.StatisticsHandler != null)
                builder.SetStatisticsHandler(_options.StatisticsHandler);
        }
    }
}
