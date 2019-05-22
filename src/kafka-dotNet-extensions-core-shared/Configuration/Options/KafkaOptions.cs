using Confluent.Kafka;
using System;
using System.Collections.Generic;

namespace kafka_dotNet_extensions_core.Configuration
{
    public class ProducerOptions<TKey, TValue>
    {
        public ISerializer<TKey> KeySerializer { get; set; } = null;
        public ISerializer<TValue> ValueSerializer { get; set; } = null;
        public Action<IProducer<TKey, TValue>, Error> ErrorHandler { get; set; } = null;
        public Action<IProducer<TKey, TValue>, LogMessage> LogHandler { get; set; } = null;
        public Action<IProducer<TKey, TValue>, string> StatisticsHandler { get; set; } = null;
    }

    public class ConsumerOptions<TKey, TValue>
    {
        public IDeserializer<TKey> KeyDeserializer { get; set; } = null;
        public IDeserializer<TValue> ValueDeserializer { get; set; } = null;
        public Action<IConsumer<TKey, TValue>, Error> ErrorHandler { get; set; } = null;
        public Action<IConsumer<TKey, TValue>, LogMessage> LogHandler { get; set; } = null;
        public Action<IConsumer<TKey, TValue>, CommittedOffsets> OffsetsCommittedHandler { get; set; } = null;
        public Action<IConsumer<TKey, TValue>, List<TopicPartition>> PartitionAssignmentHandler { get; set; } = null;
        public Action<IConsumer<TKey, TValue>, List<TopicPartitionOffset>> PartitionsRevokedHandler { get; set; } = null;
        public Action<IConsumer<TKey, TValue>, string> StatisticsHandler { get; set; } = null;
    }

}
