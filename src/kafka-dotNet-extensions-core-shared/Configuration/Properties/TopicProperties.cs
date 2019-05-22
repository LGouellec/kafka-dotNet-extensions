using kafka_dotNet_extensions_core.Attributes;
using System.ComponentModel;

namespace kafka_dotNet_extensions_core
{
    /// <summary>
    /// 
    /// </summary>
    public class TopicProperties : BaseProperties
    {
        /// <summary>
        /// This field indicates the number of acknowledgements the leader broker must receive from ISR brokers before responding to the request: 0=Broker does not send any response/ack to client, -1 or all=Broker will block until message is committed by all in sync replicas (ISRs). If there are less than min.insync.replicas (broker configuration) in the ISR set the produce request will fail. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "acks")]
        [DefaultValue(-1)]
        public int Acks { get; set; }

        /// <summary>
        /// The ack timeout of the producer request in milliseconds. This value is only enforced by the broker and relies on request.required.acks being != 0. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "request.timeout.ms")]
        [DefaultValue(5000)]
        public int RequestTimeoutMs { get; set; }

        /// <summary>
        /// Local message timeout. This value is only enforced locally and limits the time a produced message waits for successful delivery. A time of 0 is infinite. This is the maximum time librdkafka may use to deliver a message (including retries). Delivery error occurs when either the retry count or the message timeout are exceeded. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "message.timeout.ms")]
        [DefaultValue(300000)]
        public int MessageTimeoutMs { get; set; }

        /// <summary>
        /// Partitioner: random - random distribution, consistent - CRC32 hash of key (Empty and NULL keys are mapped to single partition), consistent_random - CRC32 hash of key (Empty and NULL keys are randomly partitioned), murmur2 - Java Producer compatible Murmur2 hash of key (NULL keys are mapped to single partition), murmur2_random - Java Producer compatible Murmur2 hash of key (NULL keys are randomly partitioned. This is functionally equivalent to the default partitioner in the Java Producer.). 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "partitioner")]
        [DefaultValue("consistent_random")]
        public string Partitioner { get; set; }

        /// <summary>
        /// Compression level parameter for algorithm selected by configuration property compression.codec. Higher values will result in better compression at the cost of more CPU usage. Usable range is algorithm-dependent: [0-9] for gzip; [0-12] for lz4; only 0 for snappy; -1 = codec-dependent default compression level. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "compression.level")]
        [DefaultValue(-1)]
        public int CompressionLevel { get; set; }

        /// <summary>
        /// Action to take when there is no initial offset in offset store or the desired offset is out of range: 'smallest','earliest' - automatically reset the offset to the smallest offset, 'largest','latest' - automatically reset the offset to the largest offset, 'error' - trigger an error which is retrieved by consuming messages and checking 'message->err'. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "auto.offset.reset")]
        [DefaultValue("largest")]
        public string AutoOffsetReset { get; set; }
    }
}
