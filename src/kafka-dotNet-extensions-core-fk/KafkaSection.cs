using System.Configuration;

namespace kafka_dotNet_extensions_core
{
    /// <summary>
    /// https://github.com/edenhill/librdkafka/blob/master/CONFIGURATION.md
    /// </summary>
    public sealed class KafkaSection : ConfigurationSection
    {
        /// <summary>
        /// Instanciate a new section for kafka component
        /// </summary>
        public KafkaSection()
        {

        }

        #region General Properties
        /// <summary>
        /// Client identifier. 
        /// </summary>
        [ConfigurationProperty("clientId", IsRequired = true, IsKey = true)]
        public string ClientId
        {
            get { return (string)this["clientId"]; }
            set { this["clientId"] = value; }
        }

        /// <summary>
        /// Client identifier. 
        /// </summary>
        [ConfigurationProperty("groupId", IsRequired = true, IsKey = true)]
        public string GroupId
        {
            get { return (string)this["groupId"]; }
            set { this["groupId"] = value; }
        }

        /// <summary>
        /// Initial list of brokers as a CSV list of broker host or host:port. The application may also use rd_kafka_brokers_add() to add brokers during runtime. 
        /// </summary>
        [ConfigurationProperty("brokers", IsRequired = true, IsKey = true)]
        public string Brokers
        {
            get { return (string)this["brokers"]; }
            set { this["brokers"] = value; }
        }

        /// <summary>
        /// Log broker disconnects. It might be useful to turn this off when interacting with 0.9 brokers with an aggressive connection.max.idle.ms value. 
        /// </summary>
        [ConfigurationProperty("securityProtocol", DefaultValue = "plaintext", IsKey = true)]
        [RegexStringValidator("(plaintext)|(ssl)|(sasl_plaintext)|(sasl_ssl)")]
        public string SecurityProtocol
        {
            get { return (string)this["securityProtocol"]; }
            set { this["securityProtocol"] = value; }
        }

        /// <summary>
        /// Alias for metadata.broker.list: Initial list of brokers as a CSV list of broker host or host:port. The application may also use rd_kafka_brokers_add() to add brokers during runtime. 
        /// </summary>
        [ConfigurationProperty("messageMaxBytes", DefaultValue = 1000000)]
        public int MessageMaxBytes
        {
            get { return (int)this["messageMaxBytes"]; }
            set { this["messageMaxBytes"] = value; }
        }

        /// <summary>
        /// Alias for metadata.broker.list: Initial list of brokers as a CSV list of broker host or host:port. The application may also use rd_kafka_brokers_add() to add brokers during runtime. 
        /// </summary>
        [ConfigurationProperty("messageCopyMaxBytes", DefaultValue = 65535)]
        public int MessageCopyMaxBytes
        {
            get { return (int)this["messageCopyMaxBytes"]; }
            set { this["messageCopyMaxBytes"] = value; }
        }

        /// <summary>
        /// Alias for metadata.broker.list: Initial list of brokers as a CSV list of broker host or host:port. The application may also use rd_kafka_brokers_add() to add brokers during runtime. 
        /// </summary>
        [ConfigurationProperty("receiveMessageMaxBytes", DefaultValue = 100000000)]
        public int ReceiveMessageMaxBytes
        {
            get { return (int)this["receiveMessageMaxBytes"]; }
            set { this["receiveMessageMaxBytes"] = value; }
        }

        /// <summary>
        /// Maximum number of in-flight requests per broker connection. This is a generic property applied to all broker communication, however it is primarily relevant to produce requests. In particular, note that other mechanisms limit the number of outstanding consumer fetch request per broker to one. 
        /// </summary>
        [ConfigurationProperty("maxInFlightRequestsPerConnection", DefaultValue = 1000000)]
        public int MaxInFlightRequestsPerConnection
        {
            get { return (int)this["maxInFlightRequestsPerConnection"]; }
            set { this["maxInFlightRequestsPerConnection"] = value; }
        }

        /// <summary>
        /// Non-topic request timeout in milliseconds. This is for metadata requests, etc.
        /// </summary>
        [ConfigurationProperty("metadataRequestTimeoutMs", DefaultValue = 60000)]
        public int MetadataRequestTimeoutMs
        {
            get { return (int)this["metadataRequestTimeoutMs"]; }
            set { this["metadataRequestTimeoutMs"] = value; }
        }

        /// <summary>
        /// Topic metadata refresh interval in milliseconds. The metadata is automatically refreshed on error and connect. Use -1 to disable the intervalled refresh.
        /// </summary>
        [ConfigurationProperty("topicMetadataRefreshIntervalMs", DefaultValue = 300000)]
        public int TopicMetadataRefreshIntervalMs
        {
            get { return (int)this["topicMetadataRefreshIntervalMs"]; }
            set { this["topicMetadataRefreshIntervalMs"] = value; }
        }

        /// <summary>
        /// Metadata cache max age. Defaults to topic.metadata.refresh.interval.ms * 3 
        /// </summary>
        [ConfigurationProperty("metadataMaxAgeMs", DefaultValue = 900000)]
        public int MetadataMaxAgeMs
        {
            get { return (int)this["metadataMaxAgeMs"]; }
            set { this["metadataMaxAgeMs"] = value; }
        }

        /// <summary>
        /// When a topic loses its leader a new metadata request will be enqueued with this initial interval, exponentially increasing until the topic metadata has been refreshed. This is used to recover quickly from transitioning leader brokers. 
        /// </summary>
        [ConfigurationProperty("topicMetadataRefreshFastIntervalMs", DefaultValue = 250)]
        public int TopicMetadataRefreshFastIntervalMs
        {
            get { return (int)this["topicMetadataRefreshFastIntervalMs"]; }
            set { this["topicMetadataRefreshFastIntervalMs"] = value; }
        }

        /// <summary>
        /// When a topic loses its leader a new metadata request will be enqueued with this initial interval, exponentially increasing until the topic metadata has been refreshed. This is used to recover quickly from transitioning leader brokers. 
        /// </summary>
        [ConfigurationProperty("topicMetadataRefreshSparse", DefaultValue = true)]
        public bool TopicMetadataRefreshSparse
        {
            get { return (bool)this["topicMetadataRefreshSparse"]; }
            set { this["topicMetadataRefreshSparse"] = value; }
        }

        /// <summary>
        /// Topic blacklist, a comma-separated list of regular expressions for matching topic names that should be ignored in broker metadata information as if the topics did not exist. 
        /// </summary>
        [ConfigurationProperty("topicBlacklist", DefaultValue = null)]
        public string TopicBlacklist
        {
            get { return (string)this["topicBlacklist"]; }
            set { this["topicBlacklist"] = value; }
        }

        /// <summary>
        /// A comma-separated list of debug contexts to enable. Detailed Producer debugging: broker,topic,msg. Consumer: consumer,cgrp,topic,fetch 
        /// </summary>
        [ConfigurationProperty("debug", DefaultValue = null)]
        public string Debug
        {
            get { return (string)this["debug"]; }
            set { this["debug"] = value; }
        }

        /// <summary>
        /// Default timeout for network requests. Producer: ProduceRequests will use the lesser value of socket.timeout.ms and remaining message.timeout.ms for the first message in the batch. Consumer: FetchRequests will use fetch.wait.max.ms + socket.timeout.ms. Admin: Admin requests will use socket.timeout.ms or explicitly set rd_kafka_AdminOptions_set_operation_timeout() value. 
        /// </summary>
        [ConfigurationProperty("socketTimeoutMs", DefaultValue = 60000)]
        public int SocketTimeoutMs
        {
            get { return (int)this["socketTimeoutMs"]; }
            set { this["socketTimeoutMs"] = value; }
        }


        /// <summary>
        /// Broker socket send buffer size. System default is used if 0. 
        /// </summary>
        [ConfigurationProperty("socketSendBufferBytes", DefaultValue = 0)]
        public int SocketSendBufferBytes
        {
            get { return (int)this["socketSendBufferBytes"]; }
            set { this["socketSendBufferBytes"] = value; }
        }

        /// <summary>
        /// Broker socket receive buffer size. System default is used if 0. 
        /// </summary>
        [ConfigurationProperty("socketReceiveBufferBytes", DefaultValue = 0)]
        public int SocketReceiveBufferBytes
        {
            get { return (int)this["socketReceiveBufferBytes"]; }
            set { this["socketReceiveBufferBytes"] = value; }
        }

        /// <summary>
        /// Enable TCP keep-alives (SO_KEEPALIVE) on broker sockets 
        /// </summary>
        [ConfigurationProperty("socketKeepAliveEnable", DefaultValue = false)]
        public bool SocketKeepAliveEnable
        {
            get { return (bool)this["socketKeepAliveEnable"]; }
            set { this["socketKeepAliveEnable"] = value; }
        }

        /// <summary>
        /// Disable the Nagle algorithm (TCP_NODELAY) on broker sockets. 
        /// </summary>
        [ConfigurationProperty("socketNagleDisable", DefaultValue = false)]
        public bool SocketNagleDisable
        {
            get { return (bool)this["socketNagleDisable"]; }
            set { this["socketNagleDisable"] = value; }
        }

        /// <summary>
        /// Disconnect from broker when this number of send failures (e.g., timed out requests) is reached. Disable with 0. WARNING: It is highly recommended to leave this setting at its default value of 1 to avoid the client and broker to become desynchronized in case of request timeouts. NOTE: The connection is automatically re-established. 
        /// </summary>
        [ConfigurationProperty("socketMaxFails", DefaultValue = 1)]
        public int SocketMaxFails
        {
            get { return (int)this["socketMaxFails"]; }
            set { this["socketMaxFails"] = value; }
        }

        /// <summary>
        /// How long to cache the broker address resolving results (milliseconds). 
        /// </summary>
        [ConfigurationProperty("brokerAddressTTL", DefaultValue = 1000)]
        public int BrokerAddressTTL
        {
            get { return (int)this["brokerAddressTTL"]; }
            set { this["brokerAddressTTL"] = value; }
        }

        /// <summary>
        /// Allowed broker IP address families: any, v4, v6 
        /// </summary>
        [ConfigurationProperty("brokerAddressFamily", DefaultValue = "any")]
        [RegexStringValidator("(any)|(v4)|(v6)")]
        public string BrokerAddressFamily
        {
            get { return (string)this["brokerAddressFamily"]; }
            set { this["brokerAddressFamily"] = value; }
        }

        /// <summary>
        /// The initial time to wait before reconnecting to a broker after the connection has been closed. The time is increased exponentially until reconnect.backoff.max.ms is reached. -25% to +50% jitter is applied to each reconnect backoff. A value of 0 disables the backoff and reconnects immediately. 
        /// </summary>
        [ConfigurationProperty("reconnectBackoffMs", DefaultValue = 100)]
        public int ReconnectBackoffMs
        {
            get { return (int)this["reconnectBackoffMs"]; }
            set { this["reconnectBackoffMs"] = value; }
        }

        /// <summary>
        /// The maximum time to wait before reconnecting to a broker after the connection has been closed. 
        /// </summary>
        [ConfigurationProperty("reconnectBackoffMaxMs", DefaultValue = 10000)]
        public int ReconnectBackoffMaxMs
        {
            get { return (int)this["reconnectBackoffMaxMs"]; }
            set { this["reconnectBackoffMaxMs"] = value; }
        }

        /// <summary>
        /// librdkafka statistics emit interval. The application also needs to register a stats callback using rd_kafka_conf_set_stats_cb(). The granularity is 1000ms. A value of 0 disables statistics. 
        /// </summary>
        [ConfigurationProperty("statisticsIntervalMs", DefaultValue = 0)]
        public int StatisticsIntervalMs
        {
            get { return (int)this["statisticsIntervalMs"]; }
            set { this["statisticsIntervalMs"] = value; }
        }

        /// <summary>
        /// See rd_kafka_conf_set_events()
        /// </summary>
        [ConfigurationProperty("enabledEvents", DefaultValue = 0)]
        public int EnabledEvents
        {
            get { return (int)this["enabledEvents"]; }
            set { this["enabledEvents"] = value; }
        }

        /// <summary>
        /// Logging level (syslog(3) levels) 
        /// </summary>
        [ConfigurationProperty("logLevel", DefaultValue = 6)]
        public int LogLevel
        {
            get { return (int)this["logLevel"]; }
            set { this["logLevel"] = value; }
        }

        /// <summary>
        /// Disable spontaneous log_cb from internal librdkafka threads, instead enqueue log messages on queue set with rd_kafka_set_log_queue() and serve log callbacks or events through the standard poll APIs. NOTE: Log messages will linger in a temporary queue until the log queue has been set. 
        /// </summary>
        [ConfigurationProperty("logQueue", DefaultValue = false)]
        public bool LogQueue
        {
            get { return (bool)this["logQueue"]; }
            set { this["logQueue"] = value; }
        }

        /// <summary>
        /// Print internal thread name in log messages (useful for debugging librdkafka internals) 
        /// </summary>
        [ConfigurationProperty("logThreadName", DefaultValue = true)]
        public bool LogThreadName
        {
            get { return (bool)this["logThreadName"]; }
            set { this["logThreadName"] = value; }
        }

        /// <summary>
        /// Log broker disconnects. It might be useful to turn this off when interacting with 0.9 brokers with an aggressive connection.max.idle.ms value. 
        /// </summary>
        [ConfigurationProperty("logConnectionClose", DefaultValue = true)]
        public bool LogConnectionClose
        {
            get { return (bool)this["logConnectionClose"]; }
            set { this["logConnectionClose"] = value; }
        }

        /// <summary>
        /// A cipher suite is a named combination of authentication, encryption, MAC and key exchange algorithm used to negotiate the security settings for a network connection using TLS or SSL network protocol. See manual page for ciphers(1) and `SSL_CTX_set_cipher_list(3). 
        /// </summary>
        [ConfigurationProperty("sslCipherSuites", DefaultValue = null)]
        public string SSLCipherSuites
        {
            get { return (string)this["sslCipherSuites"]; }
            set { this["sslCipherSuites"] = value; }
        }

        /// <summary>
        /// The supported-curves extension in the TLS ClientHello message specifies the curves (standard/named, or "explicit" GF(2^k) or GF(p)) the client is willing to have the server use. See manual page for SSL_CTX_set1_curves_list(3). OpenSSL >= 1.0.2 required. 
        /// </summary>
        [ConfigurationProperty("sslCurvesList", DefaultValue = null)]
        public string SSLCurvesList
        {
            get { return (string)this["sslCurvesList"]; }
            set { this["sslCurvesList"] = value; }
        }

        /// <summary>
        /// The client uses the TLS ClientHello signature_algorithms extension to indicate to the server which signature/hash algorithm pairs may be used in digital signatures. See manual page for SSL_CTX_set1_sigalgs_list(3). OpenSSL >= 1.0.2 required. 
        /// </summary>
        [ConfigurationProperty("sslSigalgsList", DefaultValue = null)]
        public string SSLSigalgsList
        {
            get { return (string)this["sslSigalgsList"]; }
            set { this["sslSigalgsList"] = value; }
        }

        /// <summary>
        /// Path to client"s private key (PEM) used for authentication. 
        /// </summary>
        [ConfigurationProperty("sslKeyLocation", DefaultValue = null)]
        public string SSLKeyLocation
        {
            get { return (string)this["sslKeyLocation"]; }
            set { this["sslKeyLocation"] = value; }
        }

        /// <summary>
        /// Private key passphrase.
        /// </summary>
        [ConfigurationProperty("sslKeyPassword", DefaultValue = null)]
        public string SSLKeyPassword
        {
            get { return (string)this["sslKeyPassword"]; }
            set { this["sslKeyPassword"] = value; }
        }

        /// <summary>
        /// Path to client"s public key (PEM) used for authentication. 
        /// </summary>
        [ConfigurationProperty("sslCertificateLocation", DefaultValue = null)]
        public string SSLCertificateLocation
        {
            get { return (string)this["sslCertificateLocation"]; }
            set { this["sslCertificateLocation"] = value; }
        }

        /// <summary>
        /// File or directory path to CA certificate(s) for verifying the broker"s key. 
        /// </summary>
        [ConfigurationProperty("sslCALocation", DefaultValue = null)]
        public string SSLCALocation
        {
            get { return (string)this["sslCALocation"]; }
            set { this["sslCALocation"] = value; }
        }

        /// <summary>
        /// Path to CRL for verifying broker"s certificate validity. 
        /// </summary>
        [ConfigurationProperty("sslCRLLocation", DefaultValue = null)]
        public string SSLCRLLocation
        {
            get { return (string)this["sslCRLLocation"]; }
            set { this["sslCRLLocation"] = value; }
        }

        /// <summary>
        /// Path to client"s keystore (PKCS#12) used for authentication. 
        /// </summary>
        [ConfigurationProperty("sslKeystoreLocation", DefaultValue = null)]
        public string SSLKeystoreLocation
        {
            get { return (string)this["sslKeystoreLocation"]; }
            set { this["sslKeystoreLocation"] = value; }
        }

        /// <summary>
        /// Client"s keystore (PKCS#12) password. 
        /// </summary>
        [ConfigurationProperty("sslKeystorePassword", DefaultValue = null)]
        public string SSLKeystorePassword
        {
            get { return (string)this["sslKeystorePassword"]; }
            set { this["sslKeystorePassword"] = value; }
        }

        /// <summary>
        /// SASL mechanism to use for authentication. Supported: GSSAPI, PLAIN, SCRAM-SHA-256, SCRAM-SHA-512, OAUTHBEARER. NOTE: Despite the name only one mechanism must be configured. 
        /// </summary>
        [ConfigurationProperty("saslMechanism", DefaultValue = "GSSAPI")]
        [RegexStringValidator("(GSSAPI)|(PLAIN)|(SCRAM-SHA-256)|(SCRAM-SHA-512)|(OAUTHBEARER)")]
        public string SASLMechanism
        {
            get { return (string)this["saslMechanism"]; }
            set { this["saslMechanism"] = value; }
        }

        ///// <summary>
        ///// Kerberos principal name that Kafka runs as, not including /hostname@REALM 
        ///// </summary>
        //[ConfigurationProperty("saslKerberosServiceName", DefaultValue = "kafka")]
        //public string SASLKerberosServiceName
        //{
        //    get { return (string)this["saslKerberosServiceName"]; }
        //    set { this["saslKerberosServiceName"] = value; }
        //}

        ///// <summary>
        ///// This client"s Kerberos principal name. (Not supported on Windows, will use the logon user"s principal).
        ///// </summary>
        //[ConfigurationProperty("saslKerberosPrincipal", DefaultValue = "kafkaclient")]
        //public string SASLKerberosPrincipal
        //{
        //    get { return (string)this["saslKerberosPrincipal"]; }
        //    set { this["saslKerberosPrincipal"] = value; }
        //}

        ///// <summary>
        ///// Full kerberos kinit command string, %{config.prop.name} is replaced by corresponding config object value, %{broker.name} returns the broker"s hostname. 
        ///// </summary>
        //[ConfigurationProperty("saslKerberosKinitCmd", DefaultValue = null)]
        //public string SASLKerberosKinitCmd
        //{
        //    get { return (string)this["saslKerberosKinitCmd"]; }
        //    set { this["saslKerberosKinitCmd"] = value; }
        //}

        ///// <summary>
        ///// Path to Kerberos keytab file. Uses system default if not set.NOTE: This is not automatically used but must be added to the template in sasl.kerberos.kinit.cmd as ... -t %{sasl.kerberos.keytab}. 
        ///// </summary>
        //[ConfigurationProperty("saslKerberosKeytab", DefaultValue = null)]
        //public string SASLKerberosKeytab
        //{
        //    get { return (string)this["saslKerberosKeytab"]; }
        //    set { this["saslKerberosKeytab"] = value; }
        //}

        ///// <summary>
        ///// Minimum time in milliseconds between key refresh attempts. 
        ///// </summary>
        //[ConfigurationProperty("saslKerberosMinTimeBeforeRelogin", DefaultValue = 60000)]
        //public int SASLKerberosMinTimeBeforeRelogin
        //{
        //    get { return (int)this["saslKerberosMinTimeBeforeRelogin"]; }
        //    set { this["saslKerberosMinTimeBeforeRelogin"] = value; }
        //}

        /// <summary>
        /// SASL username for use with the PLAIN and SASL-SCRAM-.. mechanisms 
        /// </summary>
        [ConfigurationProperty("saslUsername", DefaultValue = null)]
        public string SASLUsername
        {
            get { return (string)this["saslUsername"]; }
            set { this["saslUsername"] = value; }
        }

        /// <summary>
        /// SASL password for use with the PLAIN and SASL-SCRAM-.. mechanism 
        /// </summary>
        [ConfigurationProperty("saslPassword", DefaultValue = null)]
        public string SASLPassword
        {
            get { return (string)this["saslPassword"]; }
            set { this["saslPassword"] = value; }
        }

        /// <summary>
        /// SASL/OAUTHBEARER configuration. The format is implementation-dependent and must be parsed accordingly. The default unsecured token implementation (see https://tools.ietf.org/html/rfc7515#appendix-A.5) recognizes space-separated name=value pairs with valid names including principalClaimName, principal, scopeClaimName, scope, and lifeSeconds. The default value for principalClaimName is "sub", the default value for scopeClaimName is "scope", and the default value for lifeSeconds is 3600. The scope value is CSV format with the default value being no/empty scope. For example: principalClaimName=azp principal=admin scopeClaimName=roles scope=role1,role2 lifeSeconds=600. In addition, SASL extensions can be communicated to the broker via extension_[extensionname]=value. For example: principal=admin extension_traceId=123
        /// </summary>
        [ConfigurationProperty("saslOauthbearerConfig", DefaultValue = null)]
        public string SASLOauthbearerConfig
        {
            get { return (string)this["saslOauthbearerConfig"]; }
            set { this["saslOauthbearerConfig"] = value; }
        }

        /// <summary>
        /// List of plugin libraries to load (; separated). The library search path is platform dependent (see dlopen(3) for Unix and LoadLibrary() for Windows). If no filename extension is specified the platform-specific extension (such as .dll or .so) will be appended automatically.
        /// </summary>
        [ConfigurationProperty("pluginLibraryPaths", DefaultValue = null)]
        public string PluginLibraryPaths
        {
            get { return (string)this["pluginLibraryPaths"]; }
            set { this["pluginLibraryPaths"] = value; }
        }

        #endregion

        #region Consumer Properties

        /// <summary>
        /// Name of partition assignment strategy to use when elected group leader assigns partitions to group members. 
        /// </summary>
        [ConfigurationProperty("partitionAssignmentStrategy", DefaultValue = "range,roundrobin")]
        public string PartitionAssignmentStrategy
        {
            get { return (string)this["partitionAssignmentStrategy"]; }
            set { this["partitionAssignmentStrategy"] = value; }
        }

        /// <summary>
        /// Client group session and failure detection timeout. The consumer sends periodic heartbeats (heartbeat.interval.ms) to indicate its liveness to the broker. If no hearts are received by the broker for a group member within the session timeout, the broker will remove the consumer from the group and trigger a rebalance. The allowed range is configured with the broker configuration properties group.min.session.timeout.ms and group.max.session.timeout.ms. Also see max.poll.interval.ms.
        /// </summary>
        [ConfigurationProperty("sessionTimeoutMs", DefaultValue = 10000)]
        public int SessionTimeoutMs
        {
            get { return (int)this["sessionTimeoutMs"]; }
            set { this["sessionTimeoutMs"] = value; }
        }

        /// <summary>
        /// Group session keepalive heartbeat interval. 
        /// </summary>
        [ConfigurationProperty("heartbeatIntervalMs", DefaultValue = 3000)]
        public int HeartbeatIntervalMs
        {
            get { return (int)this["heartbeatIntervalMs"]; }
            set { this["heartbeatIntervalMs"] = value; }
        }

        /// <summary>
        /// Group protocol type 
        /// </summary>
        [ConfigurationProperty("groupProtocolType", DefaultValue = "consumer")]
        public string GroupProtocolType
        {
            get { return (string)this["groupProtocolType"]; }
            set { this["groupProtocolType"] = value; }
        }

        /// <summary>
        /// How often to query for the current client group coordinator. If the currently assigned coordinator is down the configured query interval will be divided by ten to more quickly recover in case of coordinator reassignment. 
        /// </summary>
        [ConfigurationProperty("coordinatorQueryIntervalMs", DefaultValue = 600000)]
        public int CoordinatorQueryIntervalMs
        {
            get { return (int)this["coordinatorQueryIntervalMs"]; }
            set { this["coordinatorQueryIntervalMs"] = value; }
        }

        /// <summary>
        /// Maximum allowed time between calls to consume messages (e.g., rd_kafka_consumer_poll()) for high-level consumers. If this interval is exceeded the consumer is considered failed and the group will rebalance in order to reassign the partitions to another consumer group member. Warning: Offset commits may be not possible at this point. Note: It is recommended to set enable.auto.offset.store=false for long-time processing applications and then explicitly store offsets (using offsets_store()) after message processing, to make sure offsets are not auto-committed prior to processing has finished. The interval is checked two times per second. See KIP-62 for more information. 
        /// </summary>
        [ConfigurationProperty("maxPollIntervalMs", DefaultValue = 300000)]
        public int MaxPollIntervalMs
        {
            get { return (int)this["maxPollIntervalMs"]; }
            set { this["maxPollIntervalMs"] = value; }
        }

        /// <summary>
        /// Automatically and periodically commit offsets in the background. Note: setting this to false does not prevent the consumer from fetching previously committed start offsets. To circumvent this behaviour set specific start offsets per partition in the call to assign(). 
        /// </summary>
        [ConfigurationProperty("enableAutoCommit", DefaultValue = true)]
        public bool EnableAutoCommit
        {
            get { return (bool)this["enableAutoCommit"]; }
            set { this["enableAutoCommit"] = value; }
        }

        /// <summary>
        /// The frequency in milliseconds that the consumer offsets are committed (written) to offset storage. (0 = disable). This setting is used by the high-level consumer. 
        /// </summary>
        [ConfigurationProperty("autoCommitIntervalMs", DefaultValue = 5000)]
        public int AutoCommitIntervalMs
        {
            get { return (int)this["autoCommitIntervalMs"]; }
            set { this["autoCommitIntervalMs"] = value; }
        }

        /// <summary>
        /// Automatically store offset of last message provided to application. The offset store is an in-memory store of the next offset to (auto-)commit for each partition. 
        /// </summary>
        [ConfigurationProperty("enableAutoOffsetStore", DefaultValue = true)]
        public bool EnableAutoOffsetStore
        {
            get { return (bool)this["enableAutoOffsetStore"]; }
            set { this["enableAutoOffsetStore"] = value; }
        }

        /// <summary>
        /// Minimum number of messages per topic+partition librdkafka tries to maintain in the local consumer queue. 
        /// </summary>
        [ConfigurationProperty("queuedMinMessages", DefaultValue = 100000)]
        public int QueuedMinMessages
        {
            get { return (int)this["queuedMinMessages"]; }
            set { this["queuedMinMessages"] = value; }
        }

        /// <summary>
        /// Maximum number of kilobytes per topic+partition in the local consumer queue. This value may be overshot by fetch.message.max.bytes. This property has higher priority than queued.min.messages. 
        /// </summary>
        [ConfigurationProperty("queuedMaxMessagesKbytes", DefaultValue = 1048576)]
        public int QueuedMaxMessagesKbytes
        {
            get { return (int)this["queuedMaxMessagesKbytes"]; }
            set { this["queuedMaxMessagesKbytes"] = value; }
        }

        /// <summary>
        /// Maximum time the broker may wait to fill the response with fetch.min.bytes. 
        /// </summary>
        [ConfigurationProperty("fetchWaitMaxMs", DefaultValue = 100)]
        public int FetchWaitMaxMs
        {
            get { return (int)this["fetchWaitMaxMs"]; }
            set { this["fetchWaitMaxMs"] = value; }
        }

        /// <summary>
        /// Initial maximum number of bytes per topic+partition to request when fetching messages from the broker. If the client encounters a message larger than this value it will gradually try to increase it until the entire message can be fetched. 
        /// </summary>
        [ConfigurationProperty("fetchMessageMaxBytes", DefaultValue = 1048576)]
        public int FetchMessageMaxBytes
        {
            get { return (int)this["fetchMessageMaxBytes"]; }
            set { this["fetchMessageMaxBytes"] = value; }
        }

        /// <summary>
        /// Maximum amount of data the broker shall return for a Fetch request. Messages are fetched in batches by the consumer and if the first message batch in the first non-empty partition of the Fetch request is larger than this value, then the message batch will still be returned to ensure the consumer can make progress. The maximum message batch size accepted by the broker is defined via message.max.bytes (broker config) or max.message.bytes (broker topic config). fetch.max.bytes is automatically adjusted upwards to be at least message.max.bytes (consumer config).
        /// </summary>
        [ConfigurationProperty("fetchMaxBytes", DefaultValue = 52428800)]
        public int FetchMaxBytes
        {
            get { return (int)this["fetchMaxBytes"]; }
            set { this["fetchMaxBytes"] = value; }
        }

        /// <summary>
        /// Minimum number of bytes the broker responds with. If fetch.wait.max.ms expires the accumulated data will be sent to the client regardless of this setting. 
        /// </summary>
        [ConfigurationProperty("fetchMinBytes", DefaultValue = 1)]
        public int FetchMinBytes
        {
            get { return (int)this["fetchMinBytes"]; }
            set { this["fetchMinBytes"] = value; }
        }

        /// <summary>
        /// How long to postpone the next fetch request for a topic+partition in case of a fetch error. 
        /// </summary>
        [ConfigurationProperty("fetchErrorBackoffMs", DefaultValue = 500)]
        public int FetchErrorBackoffMs
        {
            get { return (int)this["fetchErrorBackoffMs"]; }
            set { this["fetchErrorBackoffMs"] = value; }
        }

        /// <summary>
        /// Emit RD_KAFKA_RESP_ERR__PARTITION_EOF event whenever the consumer reaches the end of a partition. 
        /// </summary>
        [ConfigurationProperty("enablePartitionEOF", DefaultValue = false)]
        public bool EnablePartitionEOF
        {
            get { return (bool)this["enablePartitionEOF"]; }
            set { this["enablePartitionEOF"] = value; }
        }

        /// <summary>
        /// Verify CRC32 of consumed messages, ensuring no on-the-wire or on-disk corruption to the messages occurred. This check comes at slightly increased CPU usage. 
        /// </summary>
        [ConfigurationProperty("checkCrcs", DefaultValue = false)]
        public bool CheckCrcs
        {
            get { return (bool)this["checkCrcs"]; }
            set { this["ccheckCrcs"] = value; }
        }

        #endregion

        #region Producer Properties

        /// <summary>
        /// When set to true, the producer will ensure that messages are successfully produced exactly once and in the original produce order. The following configuration properties are adjusted automatically (if not modified by the user) when idempotence is enabled: max.in.flight.requests.per.connection=5 (must be less than or equal to 5), retries=INT32_MAX (must be greater than 0), acks=all, queuing.strategy=fifo. Producer instantation will fail if user-supplied configuration is incompatible. 
        /// </summary>
        [ConfigurationProperty("enableIdempotence", DefaultValue = false)]
        public bool EnableIdempotence
        {
            get { return (bool)this["enableIdempotence"]; }
            set { this["enableIdempotence"] = value; }
        }

        /// <summary>
        /// EXPERIMENTAL: subject to change or removal. When set to true, any error that could result in a gap in the produced message series when a batch of messages fails, will raise a fatal error (ERR__GAPLESS_GUARANTEE) and stop the producer. Messages failing due to message.timeout.ms are not covered by this guarantee. Requires enable.idempotence=true.
        /// </summary>
        [ConfigurationProperty("enableGaplessGuarantee", DefaultValue = false)]
        public bool EnableGaplessGuarantee
        {
            get { return (bool)this["enableGaplessGuarantee"]; }
            set { this["enableGaplessGuarantee"] = value; }
        }

        /// <summary>
        /// Maximum number of messages allowed on the producer queue. This queue is shared by all topics and partitions. 
        /// </summary>
        [ConfigurationProperty("queueBufferingMaxMessages", DefaultValue = 100000)]
        public int QueueBufferingMaxMessages
        {
            get { return (int)this["queueBufferingMaxMessages"]; }
            set { this["queueBufferingMaxMessages"] = value; }
        }

        /// <summary>
        /// Maximum total message size sum allowed on the producer queue. This queue is shared by all topics and partitions. This property has higher priority than queue.buffering.max.messages. 
        /// </summary>
        [ConfigurationProperty("queueBufferingMaxKbytes", DefaultValue = 1048576)]
        public int QueueBufferingMaxKbytes
        {
            get { return (int)this["queueBufferingMaxKbytes"]; }
            set { this["queueBufferingMaxKbytes"] = value; }
        }

        /// <summary>
        /// Delay in milliseconds to wait for messages in the producer queue to accumulate before constructing message batches (MessageSets) to transmit to brokers. A higher value allows larger and more effective (less overhead, improved compression) batches of messages to accumulate at the expense of increased message delivery latency. 
        /// </summary>
        [ConfigurationProperty("queueBufferingMaxMs", DefaultValue = 0)]
        public int QueueBufferingMaxMs
        {
            get { return (int)this["queueBufferingMaxMs"]; }
            set { this["queueBufferingMaxMs"] = value; }
        }

        /// <summary>
        /// How many times to retry sending a failing Message. Note: retrying may cause reordering unless enable.idempotence is set to true. 
        /// </summary>
        [ConfigurationProperty("messageSendMaxRetries", DefaultValue = 2)]
        public int MessageSendMaxRetries
        {
            get { return (int)this["messageSendMaxRetries"]; }
            set { this["messageSendMaxRetries"] = value; }
        }

        /// <summary>
        /// The backoff time in milliseconds before retrying a protocol request. 
        /// </summary>
        [ConfigurationProperty("retryBackoffMs", DefaultValue = 100)]
        public int RetryBackoffMs
        {
            get { return (int)this["retryBackoffMs"]; }
            set { this["retryBackoffMs"] = value; }
        }

        /// <summary>
        /// The threshold of outstanding not yet transmitted broker requests needed to backpressure the producer"s message accumulator. If the number of not yet transmitted requests equals or exceeds this number, produce request creation that would have otherwise been triggered (for example, in accordance with linger.ms) will be delayed. A lower number yields larger and more effective batches. A higher value can improve latency when using compression on slow machines. 
        /// </summary>
        [ConfigurationProperty("queueBufferingBackPressureThreshold", DefaultValue = 1)]
        public int QueueBufferingBackPressureThreshold
        {
            get { return (int)this["queueBufferingBackPressureThreshold"]; }
            set { this["queueBufferingBackPressureThreshold"] = value; }
        }

        /// <summary>
        /// compression codec to use for compressing message sets. This is the default value for all topics, may be overridden by the topic configuration property compression.codec
        /// </summary>
        [ConfigurationProperty("compressionCodec", DefaultValue = "none")]
        [RegexStringValidator("(none)|(gzip)|(snappy)|(lz4)|(zstd)")]
        public string CompressionCodec
        {
            get { return (string)this["compressionCodec"]; }
            set { this["compressionCodec"] = value; }
        }

        /// <summary>
        /// Maximum number of messages batched in one MessageSet. The total MessageSet size is also limited by message.max.bytes
        /// </summary>
        [ConfigurationProperty("batchNumMessages", DefaultValue = 10000)]
        public int BatchNumMessages
        {
            get { return (int)this["batchNumMessages"]; }
            set { this["batchNumMessages"] = value; }
        }

        /// <summary>
        /// Only provide delivery reports for failed messages.
        /// </summary>
        [ConfigurationProperty("deliveryReportOnlyError", DefaultValue = false)]
        public bool DeliveryReportOnlyError
        {
            get { return (bool)this["deliveryReportOnlyError"]; }
            set { this["deliveryReportOnlyError"] = value; }
        }

        #endregion

        #region Topic Properties

        /// <summary>
        /// This field indicates the number of acknowledgements the leader broker must receive from ISR brokers before responding to the request: 0=Broker does not send any response/ack to client, -1 or all=Broker will block until message is committed by all in sync replicas (ISRs). If there are less than min.insync.replicas (broker configuration) in the ISR set the produce request will fail. 
        /// </summary>
        [ConfigurationProperty("acks", DefaultValue = -1)]
        public int Acks
        {
            get { return (int)this["acks"]; }
            set { this["acks"] = value; }
        }

        /// <summary>
        /// The ack timeout of the producer request in milliseconds. This value is only enforced by the broker and relies on request.required.acks being != 0. 
        /// </summary>
        [ConfigurationProperty("requestTimeoutMs", DefaultValue = 5000)]
        public int RequestTimeoutMs
        {
            get { return (int)this["requestTimeoutMs"]; }
            set { this["requestTimeoutMs"] = value; }
        }

        /// <summary>
        /// Local message timeout. This value is only enforced locally and limits the time a produced message waits for successful delivery. A time of 0 is infinite. This is the maximum time librdkafka may use to deliver a message (including retries). Delivery error occurs when either the retry count or the message timeout are exceeded. 
        /// </summary>
        [ConfigurationProperty("messageTimeoutMs", DefaultValue = 300000)]
        public int MessageTimeoutMs
        {
            get { return (int)this["messageTimeoutMs"]; }
            set { this["messageTimeoutMs"] = value; }
        }

        /// <summary>
        /// Partitioner: random - random distribution, consistent - CRC32 hash of key (Empty and NULL keys are mapped to single partition), consistent_random - CRC32 hash of key (Empty and NULL keys are randomly partitioned), murmur2 - Java Producer compatible Murmur2 hash of key (NULL keys are mapped to single partition), murmur2_random - Java Producer compatible Murmur2 hash of key (NULL keys are randomly partitioned. This is functionally equivalent to the default partitioner in the Java Producer.). 
        /// </summary>
        [ConfigurationProperty("partitioner", DefaultValue = "consistent_random")]
        public string Partitioner
        {
            get { return (string)this["partitioner"]; }
            set { this["partitioner"] = value; }
        }

        /// <summary>
        /// Compression level parameter for algorithm selected by configuration property compression.codec. Higher values will result in better compression at the cost of more CPU usage. Usable range is algorithm-dependent: [0-9] for gzip; [0-12] for lz4; only 0 for snappy; -1 = codec-dependent default compression level. 
        /// </summary>
        [ConfigurationProperty("compressionLevel", DefaultValue = -1)]
        public int CompressionLevel
        {
            get { return (int)this["compressionLevel"]; }
            set { this["compressionLevel"] = value; }
        }

        /// <summary>
        /// Action to take when there is no initial offset in offset store or the desired offset is out of range: 'smallest','earliest' - automatically reset the offset to the smallest offset, 'largest','latest' - automatically reset the offset to the largest offset, 'error' - trigger an error which is retrieved by consuming messages and checking 'message->err'. 
        /// </summary>
        [ConfigurationProperty("autoOffsetReset", DefaultValue = "largest")]
        [RegexStringValidator("(smallest)|(earliest)|(beginning)|(largest)|(latest)|(end)|(error)")]
        public string AutoOffsetReset
        {
            get { return (string)this["autoOffsetReset"]; }
            set { this["autoOffsetReset"] = value; }
        }


        #endregion
    }
}
