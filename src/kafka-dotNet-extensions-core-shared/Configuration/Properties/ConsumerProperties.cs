using kafka_dotNet_extensions_core.Attributes;

namespace kafka_dotNet_extensions_core
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsumerProperties
    {
        /// <summary>
        /// Name of partition assignment strategy to use when elected group leader assigns partitions to group members. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "partition.assignment.strategy")]
        public string PartitionAssignmentStrategy { get; set; }

        /// <summary>
        /// Client group session and failure detection timeout. The consumer sends periodic heartbeats (heartbeat.interval.ms) to indicate its liveness to the broker. If no hearts are received by the broker for a group member within the session timeout, the broker will remove the consumer from the group and trigger a rebalance. The allowed range is configured with the broker configuration properties group.min.session.timeout.ms and group.max.session.timeout.ms. Also see max.poll.interval.ms.
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "session.timeout.ms")]
        public int SessionTimeoutMs { get; set; }

        /// <summary>
        /// Group session keepalive heartbeat interval. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "heartbeat.interval.ms")]
        public int HeartbeatIntervalMs { get; set; }

        /// <summary>
        /// Group protocol type 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "group.protocol.type")]
        public string GroupProtocolType { get; set; }

        /// <summary>
        /// How often to query for the current client group coordinator. If the currently assigned coordinator is down the configured query interval will be divided by ten to more quickly recover in case of coordinator reassignment. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "coordinator.query.interval.ms")]
        public int CoordinatorQueryIntervalMs { get; set; }

        /// <summary>
        /// Maximum allowed time between calls to consume messages (e.g., rd_kafka_consumer_poll()) for high-level consumers. If this interval is exceeded the consumer is considered failed and the group will rebalance in order to reassign the partitions to another consumer group member. Warning: Offset commits may be not possible at this point. Note: It is recommended to set enable.auto.offset.store=false for long-time processing applications and then explicitly store offsets (using offsets_store()) after message processing, to make sure offsets are not auto-committed prior to processing has finished. The interval is checked two times per second. See KIP-62 for more information. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "max.poll.interval.ms")]
        public int MaxPollIntervalMs { get; set; }

        /// <summary>
        /// Automatically and periodically commit offsets in the background. Note: setting this to false does not prevent the consumer from fetching previously committed start offsets. To circumvent this behaviour set specific start offsets per partition in the call to assign(). 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "enable.auto.commit")]
        public bool EnableAutoCommit { get; set; }

        /// <summary>
        /// The frequency in milliseconds that the consumer offsets are committed (written) to offset storage. (0 = disable). This setting is used by the high-level consumer. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "auto.commit.interval.ms")]
        public int AutoCommitIntervalMs { get; set; }

        /// <summary>
        /// Automatically store offset of last message provided to application. The offset store is an in-memory store of the next offset to (auto-)commit for each partition. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "enable.auto.offset.store")]
        public bool EnableAutoOffsetStore { get; set; }

        /// <summary>
        /// Minimum number of messages per topic+partition librdkafka tries to maintain in the local consumer queue. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "queued.min.messages")]
        public int QueuedMinMessages { get; set; }

        /// <summary>
        /// Maximum number of kilobytes per topic+partition in the local consumer queue. This value may be overshot by fetch.message.max.bytes. This property has higher priority than queued.min.messages. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "queued.max.messages.kbytes")]
        public int QueuedMaxMessagesKbytes { get; set; }

        /// <summary>
        /// Maximum time the broker may wait to fill the response with fetch.min.bytes. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "fetch.wait.max.ms")]
        public int FetchWaitMaxMs { get; set; }

        /// <summary>
        /// Initial maximum number of bytes per topic+partition to request when fetching messages from the broker. If the client encounters a message larger than this value it will gradually try to increase it until the entire message can be fetched. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "fetch.message.max.bytes")]
        public int FetchMessageMaxBytes { get; set; }

        /// <summary>
        /// Maximum amount of data the broker shall return for a Fetch request. Messages are fetched in batches by the consumer and if the first message batch in the first non-empty partition of the Fetch request is larger than this value, then the message batch will still be returned to ensure the consumer can make progress. The maximum message batch size accepted by the broker is defined via message.max.bytes (broker config) or max.message.bytes (broker topic config). fetch.max.bytes is automatically adjusted upwards to be at least message.max.bytes (consumer config).
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "fetch.max.bytes")]
        public int FetchMaxBytes { get; set; }

        /// <summary>
        /// Minimum number of bytes the broker responds with. If fetch.wait.max.ms expires the accumulated data will be sent to the client regardless of this setting. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "fetch.min.bytes")]
        public int FetchMinBytes { get; set; }

        /// <summary>
        /// How long to postpone the next fetch request for a topic+partition in case of a fetch error. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "fetch.error.backoff.ms")]
        public int FetchErrorBackoffMs { get; set; }

        /// <summary>
        /// Emit RD_KAFKA_RESP_ERR__PARTITION_EOF event whenever the consumer reaches the end of a partition. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "enable.partition.eof")]
        public bool EnablePartitionEOF { get; set; }

        /// <summary>
        /// Verify CRC32 of consumed messages, ensuring no on-the-wire or on-disk corruption to the messages occurred. This check comes at slightly increased CPU usage. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "check.crcs")]
        public bool CheckCrcs { get; set; }
    }
}
