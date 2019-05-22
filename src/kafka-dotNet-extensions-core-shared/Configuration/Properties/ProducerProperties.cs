using kafka_dotNet_extensions_core.Attributes;
using System.ComponentModel;

namespace kafka_dotNet_extensions_core
{
    public class ProducerProperties : BaseProperties
    {
        /// <summary>
        /// When set to true, the producer will ensure that messages are successfully produced exactly once and in the original produce order. The following configuration properties are adjusted automatically (if not modified by the user) when idempotence is enabled: max.in.flight.requests.per.connection=5 (must be less than or equal to 5), retries=INT32_MAX (must be greater than 0), acks=all, queuing.strategy=fifo. Producer instantation will fail if user-supplied configuration is incompatible. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "enable.idempotence")]
        [DefaultValue(false)]
        public bool EnableIdempotence { get; set; }

        /// <summary>
        /// EXPERIMENTAL: subject to change or removal. When set to true, any error that could result in a gap in the produced message series when a batch of messages fails, will raise a fatal error (ERR__GAPLESS_GUARANTEE) and stop the producer. Messages failing due to message.timeout.ms are not covered by this guarantee. Requires enable.idempotence=true.
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "enable.gapless.guarantee")]
        [DefaultValue(false)]
        public bool EnableGaplessGuarantee { get; set; }

        /// <summary>
        /// Maximum number of messages allowed on the producer queue. This queue is shared by all topics and partitions. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "queue.buffering.max.messages")]
        [DefaultValue(100000)]
        public int QueueBufferingMaxMessages { get; set; }

        /// <summary>
        /// Maximum total message size sum allowed on the producer queue. This queue is shared by all topics and partitions. This property has higher priority than queue.buffering.max.messages. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "queue.buffering.max.kbytes")]
        [DefaultValue(1048576)]
        public int QueueBufferingMaxKbytes { get; set; }

        /// <summary>
        /// Delay in milliseconds to wait for messages in the producer queue to accumulate before constructing message batches (MessageSets) to transmit to brokers. A higher value allows larger and more effective (less overhead, improved compression) batches of messages to accumulate at the expense of increased message delivery latency. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "queue.buffering.max.ms")]
        [DefaultValue(0)]
        public int QueueBufferingMaxMs { get; set; }

        /// <summary>
        /// How many times to retry sending a failing Message. Note: retrying may cause reordering unless enable.idempotence is set to true. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "message.send.max.retries")]
        [DefaultValue(2)]
        public int MessageSendMaxRetries { get; set; }
        /// <summary>
        /// The backoff time in milliseconds before retrying a protocol request. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "retry.backoff.ms")]
        [DefaultValue(100)]
        public int RetryBackoffMs { get; set; }

        /// <summary>
        /// The threshold of outstanding not yet transmitted broker requests needed to backpressure the producer"s message accumulator. If the number of not yet transmitted requests equals or exceeds this number, produce request creation that would have otherwise been triggered (for example, in accordance with linger.ms) will be delayed. A lower number yields larger and more effective batches. A higher value can improve latency when using compression on slow machines. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "queue.buffering.backpressure.threshold")]
        [DefaultValue(1)]
        public int QueueBufferingBackPressureThreshold { get; set; }

        /// <summary>
        /// compression codec to use for compressing message sets. This is the default value for all topics, may be overridden by the topic configuration property compression.codec
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "compression.codec")]
        [DefaultValue("none")]
        public string CompressionCodec { get; set; }

        /// <summary>
        /// Maximum number of messages batched in one MessageSet. The total MessageSet size is also limited by message.max.bytes
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "batch.num.messages")]
        [DefaultValue(10000)]
        public int BatchNumMessages { get; set; }

        /// <summary>
        /// Only provide delivery reports for failed messages.
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "delivery.report.only.error")]
        [DefaultValue(false)]
        public bool DeliveryReportOnlyError { get; set; }
    }
}
