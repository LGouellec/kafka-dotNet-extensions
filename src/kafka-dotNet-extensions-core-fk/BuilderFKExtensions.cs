using kafka_dotNet_extensions_core;
using kafka_dotNet_extensions_core.Configuration;
using System.Configuration;

namespace kafka_dotNet_extensions_core
{
    /// <summary>
    /// 
    /// </summary>
    public static class BuilderFKExtensions
    {
        public static ProducerBuilder<TKey, TValue> UseSectionConfiguration<TKey, TValue>(this ProducerBuilder<TKey, TValue> builder)
        {
            return (ProducerBuilder<TKey, TValue>)builder.UseConfiguration(null);
        }

        public static ConsumerBuilder<TKey, TValue> UseSectionConfiguration<TKey, TValue>(this ConsumerBuilder<TKey, TValue> builder, params string[] topics)
        {
            return (ConsumerBuilder<TKey, TValue>)builder.UseConfiguration(topics);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="topic"></param>
        /// <returns></returns>
        internal static IBuilder UseConfiguration(this IBuilder builder, params string[] topics)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as System.Configuration.Configuration;
            var section = config.GetSection("KafkaSection") as KafkaSection;
            if (section != null)
            {
                return builder.AddBrokers(section.Brokers.Split(','))
                    .SetCliendId(section.ClientId)
                    .WithGroupId(section.GroupId)
                    .ForTopics(topics)
                    .UseGeneralProperties(new GeneralProperties
                    {
                        SecurityProtocol = section.SecurityProtocol,
                        MessageMaxBytes = section.MessageMaxBytes,
                        MessageCopyMaxBytes = section.MessageCopyMaxBytes,
                        ReceiveMessageMaxBytes = section.ReceiveMessageMaxBytes,
                        MaxInFlightRequestsPerConnection = section.MaxInFlightRequestsPerConnection,
                        MetadataRequestTimeoutMs = section.MetadataRequestTimeoutMs,
                        TopicMetadataRefreshIntervalMs = section.TopicMetadataRefreshIntervalMs,
                        MetadataMaxAgeMs = section.MetadataMaxAgeMs,
                        TopicMetadataRefreshFastIntervalMs = section.TopicMetadataRefreshFastIntervalMs,
                        TopicMetadataRefreshSparse = section.TopicMetadataRefreshSparse,
                        TopicBlacklist = section.TopicBlacklist,
                        Debug = section.Debug,
                        SocketTimeoutMs = section.SocketTimeoutMs,
                        SocketSendBufferBytes = section.SocketSendBufferBytes,
                        SocketReceiveBufferBytes = section.SocketReceiveBufferBytes,
                        SocketKeepAliveEnable = section.SocketKeepAliveEnable,
                        SocketNagleDisable = section.SocketNagleDisable,
                        SocketMaxFails = section.SocketMaxFails,
                        BrokerAddressTTL = section.BrokerAddressTTL,
                        BrokerAddressFamily = section.BrokerAddressFamily,
                        ReconnectBackoffMs = section.ReconnectBackoffMs,
                        ReconnectBackoffMaxMs = section.ReconnectBackoffMaxMs,
                        StatisticsIntervalMs = section.StatisticsIntervalMs,
                        EnabledEvents = section.EnabledEvents,
                        LogLevel = section.LogLevel,
                        LogQueue = section.LogQueue,
                        LogThreadName = section.LogThreadName,
                        LogConnectionClose = section.LogConnectionClose,
                        SSLCipherSuites = section.SSLCipherSuites,
                        SSLCurvesList = section.SSLCurvesList,
                        SSLSigalgsList = section.SSLSigalgsList,
                        SSLKeyLocation = section.SSLKeyLocation,
                        SSLKeyPassword = section.SSLKeyPassword,
                        SSLCertificateLocation = section.SSLCertificateLocation,
                        SSLCALocation = section.SSLCALocation,
                        SSLCRLLocation = section.SSLCRLLocation,
                        SSLKeystoreLocation = section.SSLKeystoreLocation,
                        SSLKeystorePassword = section.SSLKeystorePassword,
                        SASLMechanism = section.SASLMechanism,
                        //SASLKerberosServiceName = section.SASLKerberosServiceName,
                        //SASLKerberosPrincipal = section.SASLKerberosPrincipal,
                        //SASLKerberosKinitCmd = section.SASLKerberosKinitCmd,
                        //SASLKerberosKeytab = section.SASLKerberosKeytab,
                        //SASLKerberosMinTimeBeforeRelogin = section.SASLKerberosMinTimeBeforeRelogin,
                        SASLUsername = section.SASLUsername,
                        SASLPassword = section.SASLPassword,
                        SASLOauthbearerConfig = section.SASLOauthbearerConfig,
                        PluginLibraryPaths = section.PluginLibraryPaths
                    })
                    .UseConsumerProperties(new ConsumerProperties
                    {
                        PartitionAssignmentStrategy = section.PartitionAssignmentStrategy,
                        SessionTimeoutMs = section.SessionTimeoutMs,
                        HeartbeatIntervalMs = section.HeartbeatIntervalMs,
                        GroupProtocolType = section.GroupProtocolType,
                        CoordinatorQueryIntervalMs = section.CoordinatorQueryIntervalMs,
                        MaxPollIntervalMs = section.MaxPollIntervalMs,
                        EnableAutoCommit = section.EnableAutoCommit,
                        AutoCommitIntervalMs = section.AutoCommitIntervalMs,
                        EnableAutoOffsetStore = section.EnableAutoOffsetStore,
                        QueuedMinMessages = section.QueuedMinMessages,
                        QueuedMaxMessagesKbytes = section.QueuedMaxMessagesKbytes,
                        FetchWaitMaxMs = section.FetchWaitMaxMs,
                        FetchMessageMaxBytes = section.FetchMessageMaxBytes,
                        FetchMaxBytes = section.FetchMaxBytes,
                        FetchMinBytes = section.FetchMinBytes,
                        FetchErrorBackoffMs = section.FetchErrorBackoffMs,
                        EnablePartitionEOF = section.EnablePartitionEOF,
                        CheckCrcs = section.CheckCrcs
                    })
                    .UseProducerProperties(new ProducerProperties
                    {
                        EnableIdempotence = section.EnableIdempotence,
                        EnableGaplessGuarantee = section.EnableGaplessGuarantee,
                        QueueBufferingMaxMessages = section.QueueBufferingMaxMessages,
                        QueueBufferingMaxKbytes = section.QueueBufferingMaxKbytes,
                        QueueBufferingMaxMs = section.QueueBufferingMaxMs,
                        MessageSendMaxRetries = section.MessageSendMaxRetries,
                        RetryBackoffMs = section.RetryBackoffMs,
                        QueueBufferingBackPressureThreshold = section.QueueBufferingBackPressureThreshold,
                        CompressionCodec = section.CompressionCodec,
                        BatchNumMessages = section.BatchNumMessages,
                        DeliveryReportOnlyError = section.DeliveryReportOnlyError
                    })
                    .UseTopicProperties(new TopicProperties
                    {
                        Acks = section.Acks,
                        RequestTimeoutMs = section.RequestTimeoutMs,
                        MessageTimeoutMs = section.MessageTimeoutMs,
                        Partitioner = section.Partitioner,
                        CompressionLevel = section.CompressionLevel,
                        AutoOffsetReset = section.AutoOffsetReset
                    });
            }
            else
                return builder;
        }
    }
}
