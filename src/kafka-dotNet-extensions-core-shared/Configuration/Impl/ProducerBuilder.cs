using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;

namespace kafka_dotNet_extensions_core.Configuration
{
    public class ProducerBuilder<TKey, TValue> : AbstractBuilder<TKey, TValue>
    {
        private readonly ProducerOptions<TKey, TValue> _options = new ProducerOptions<TKey, TValue>();

        public ProducerBuilder()
        {

        }

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
            SetHandlers(builder);

            producer = builder.Build();

            return producer;
        }

        public ProducerBuilder<TKey, TValue> UseOptions(Action<ProducerOptions<TKey, TValue>> action)
        {
            action(_options);
            return this;
        }

        private void SetHandlers(Confluent.Kafka.ProducerBuilder<TKey, TValue> builder)
        {
            if (_options.ErrorHandler != null)
                builder.SetErrorHandler(_options.ErrorHandler);

            if (_options.KeySerializer != null)
                builder.SetKeySerializer(_options.KeySerializer);

            if (_options.ValueSerializer != null)
                builder.SetValueSerializer(_options.ValueSerializer);

            if (_options.KeyAsyncSerializer != null)
                builder.SetKeySerializer(_options.KeyAsyncSerializer);

            if (_options.ValueAsyncSerializer != null)
                builder.SetValueSerializer(_options.ValueAsyncSerializer);

            if (_options.LogHandler != null)
                builder.SetLogHandler(_options.LogHandler);

            if (_options.StatisticsHandler != null)
                builder.SetStatisticsHandler(_options.StatisticsHandler);
        }
    }
}
