using kafka_dotNet_extensions_core.Attributes;

namespace kafka_dotNet_extensions_core
{
    public class GeneralProperties
    {
        /// <summary>
        /// Log broker disconnects. It might be useful to turn this off when interacting with 0.9 brokers with an aggressive connection.max.idle.ms value. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "security.protocol")]
        public string SecurityProtocol { get; set; }

        /// <summary>
        /// Alias for metadata.broker.list: Initial list of brokers as a CSV list of broker host or host:port. The application may also use rd_kafka_brokers_add() to add brokers during runtime. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "message.max.bytes")]
        public int MessageMaxBytes { get; set; }

        /// <summary>
        /// Alias for metadata.broker.list: Initial list of brokers as a CSV list of broker host or host:port. The application may also use rd_kafka_brokers_add() to add brokers during runtime. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "message.copy.max.bytes")]
        public int MessageCopyMaxBytes { get; set; }

        /// <summary>
        /// Alias for metadata.broker.list: Initial list of brokers as a CSV list of broker host or host:port. The application may also use rd_kafka_brokers_add() to add brokers during runtime. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "receive.message.max.bytes")]
        public int ReceiveMessageMaxBytes { get; set; }

        /// <summary>
        /// Maximum number of in-flight requests per broker connection. This is a generic property applied to all broker communication, however it is primarily relevant to produce requests. In particular, note that other mechanisms limit the number of outstanding consumer fetch request per broker to one. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "max.in.flight.requests.per.connection")]
        public int MaxInFlightRequestsPerConnection { get; set; }

        /// <summary>
        /// Non-topic request timeout in milliseconds. This is for metadata requests, etc.
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "metadata.request.timeout.ms")]
        public int MetadataRequestTimeoutMs { get; set; }

        /// <summary>
        /// Topic metadata refresh interval in milliseconds. The metadata is automatically refreshed on error and connect. Use -1 to disable the intervalled refresh.
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "topic.metadata.refresh.interval.ms")]
        public int TopicMetadataRefreshIntervalMs { get; set; }

        /// <summary>
        /// Metadata cache max age. Defaults to topic.metadata.refresh.interval.ms * 3 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "metadata.max.age.ms")]
        public int MetadataMaxAgeMs { get; set; }

        /// <summary>
        /// When a topic loses its leader a new metadata request will be enqueued with this initial interval, exponentially increasing until the topic metadata has been refreshed. This is used to recover quickly from transitioning leader brokers. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "topic.metadata.refresh.fast.interval.ms")]
        public int TopicMetadataRefreshFastIntervalMs { get; set; }

        /// <summary>
        /// When a topic loses its leader a new metadata request will be enqueued with this initial interval, exponentially increasing until the topic metadata has been refreshed. This is used to recover quickly from transitioning leader brokers. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "topic.metadata.refresh.sparse")]
        public bool TopicMetadataRefreshSparse { get; set; }

        /// <summary>
        /// Topic blacklist, a comma-separated list of regular expressions for matching topic names that should be ignored in broker metadata information as if the topics did not exist. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "topic.blacklist")]
        public string TopicBlacklist { get; set; }

        /// <summary>
        /// A comma-separated list of debug contexts to enable. Detailed Producer debugging: broker,topic,msg. Consumer: consumer,cgrp,topic,fetch 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "debug")]
        public string Debug { get; set; }

        /// <summary>
        /// Default timeout for network requests. Producer: ProduceRequests will use the lesser value of socket.timeout.ms and remaining message.timeout.ms for the first message in the batch. Consumer: FetchRequests will use fetch.wait.max.ms + socket.timeout.ms. Admin: Admin requests will use socket.timeout.ms or explicitly set rd_kafka_AdminOptions_set_operation_timeout() value. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "socket.timeout.ms")]
        public int SocketTimeoutMs { get; set; }


        /// <summary>
        /// Broker socket send buffer size. System default is used if 0. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "socket.send.buffer.bytes")]
        public int SocketSendBufferBytes { get; set; }

        /// <summary>
        /// Broker socket receive buffer size. System default is used if 0. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "socket.receive.buffer.bytes")]
        public int SocketReceiveBufferBytes { get; set; }

        /// <summary>
        /// Enable TCP keep-alives (SO_KEEPALIVE) on broker sockets 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "socket.keepalive.enable")]
        public bool SocketKeepAliveEnable { get; set; }

        /// <summary>
        /// Disable the Nagle algorithm (TCP_NODELAY) on broker sockets. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "socket.nagle.disable")]
        public bool SocketNagleDisable { get; set; }

        /// <summary>
        /// Disconnect from broker when this number of send failures (e.g., timed out requests) is reached. Disable with 0. WARNING: It is highly recommended to leave this setting at its default value of 1 to avoid the client and broker to become desynchronized in case of request timeouts. NOTE: The connection is automatically re-established. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "socket.max.fails")]
        public int SocketMaxFails { get; set; }

        /// <summary>
        /// How long to cache the broker address resolving results (milliseconds). 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "broker.address.ttl")]
        public int BrokerAddressTTL { get; set; }

        /// <summary>
        /// Allowed broker IP address families: any, v4, v6 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "broker.address.family")]
        public string BrokerAddressFamily { get; set; }

        /// <summary>
        /// The initial time to wait before reconnecting to a broker after the connection has been closed. The time is increased exponentially until reconnect.backoff.max.ms is reached. -25% to +50% jitter is applied to each reconnect backoff. A value of 0 disables the backoff and reconnects immediately. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "reconnect.backoff.ms")]
        public int ReconnectBackoffMs { get; set; }

        /// <summary>
        /// The maximum time to wait before reconnecting to a broker after the connection has been closed. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "reconnect.backoff.max.ms")]
        public int ReconnectBackoffMaxMs { get; set; }

        /// <summary>
        /// librdkafka statistics emit interval. The application also needs to register a stats callback using rd_kafka_conf_set_stats_cb(). The granularity is 1000ms. A value of 0 disables statistics. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "statistics.interval.ms")]
        public int StatisticsIntervalMs { get; set; }

        /// <summary>
        /// See rd_kafka_conf_set_events()
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "enabled_events")]
        public int EnabledEvents { get; set; }

        /// <summary>
        /// Logging level (syslog(3) levels) 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "log_level")]
        public int LogLevel { get; set; }

        /// <summary>
        /// Disable spontaneous log_cb from internal librdkafka threads, instead enqueue log messages on queue set with rd_kafka_set_log_queue() and serve log callbacks or events through the standard poll APIs. NOTE: Log messages will linger in a temporary queue until the log queue has been set. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "log.queue")]
        public bool LogQueue { get; set; }

        /// <summary>
        /// Print internal thread name in log messages (useful for debugging librdkafka internals) 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "log.thread.name")]
        public bool LogThreadName { get; set; }

        /// <summary>
        /// Log broker disconnects. It might be useful to turn this off when interacting with 0.9 brokers with an aggressive connection.max.idle.ms value. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "log.connection.close")]
        public bool LogConnectionClose { get; set; }

        /// <summary>
        /// A cipher suite is a named combination of authentication, encryption, MAC and key exchange algorithm used to negotiate the security settings for a network connection using TLS or SSL network protocol. See manual page for ciphers(1) and `SSL_CTX_set_cipher_list(3). 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "ssl.cipher.suites")]
        public string SSLCipherSuites { get; set; }

        /// <summary>
        /// The supported-curves extension in the TLS ClientHello message specifies the curves (standard/named, or "explicit" GF(2^k) or GF(p)) the client is willing to have the server use. See manual page for SSL_CTX_set1_curves_list(3). OpenSSL >= 1.0.2 required. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "ssl.curves.list")]
        public string SSLCurvesList { get; set; }

        /// <summary>
        /// The client uses the TLS ClientHello signature_algorithms extension to indicate to the server which signature/hash algorithm pairs may be used in digital signatures. See manual page for SSL_CTX_set1_sigalgs_list(3). OpenSSL >= 1.0.2 required. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "ssl.sigalgs.list")]
        public string SSLSigalgsList { get; set; }

        /// <summary>
        /// Path to client"s private key (PEM) used for authentication. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "ssl.key.location")]
        public string SSLKeyLocation { get; set; }

        /// <summary>
        /// Private key passphrase.
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "ssl.key.password")]
        public string SSLKeyPassword { get; set; }

        /// <summary>
        /// Path to client"s public key (PEM) used for authentication. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "ssl.certificate.location")]
        public string SSLCertificateLocation { get; set; }

        /// <summary>
        /// File or directory path to CA certificate(s) for verifying the broker"s key. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "ssl.ca.location")]
        public string SSLCALocation { get; set; }

        /// <summary>
        /// Path to CRL for verifying broker"s certificate validity. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "ssl.crl.location")]
        public string SSLCRLLocation { get; set; }

        /// <summary>
        /// Path to client"s keystore (PKCS#12) used for authentication. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "ssl.keystore.location")]
        public string SSLKeystoreLocation { get; set; }

        /// <summary>
        /// Client"s keystore (PKCS#12) password. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "ssl.keystore.password")]
        public string SSLKeystorePassword { get; set; }

        /// <summary>
        /// SASL mechanism to use for authentication. Supported: GSSAPI, PLAIN, SCRAM-SHA-256, SCRAM-SHA-512, OAUTHBEARER. NOTE: Despite the name only one mechanism must be configured. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "sasl.mechanism")]
        public string SASLMechanism { get; set; }
        /// <summary>
        /// Kerberos principal name that Kafka runs as, not including /hostname@REALM 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "sasl.kerberos.service.name")]
        public string SASLKerberosServiceName { get; set; }

        /// <summary>
        /// This client"s Kerberos principal name. (Not supported on Windows, will use the logon user"s principal).
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "sasl.kerberos.principal")]
        public string SASLKerberosPrincipal { get; set; }

        /// <summary>
        /// Full kerberos kinit command string, %{config.prop.name} is replaced by corresponding config object value, %{broker.name} returns the broker"s hostname. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "sasl.kerberos.kinit.cmd")]
        public string SASLKerberosKinitCmd { get; set; }

        /// <summary>
        /// Path to Kerberos keytab file. Uses system default if not set.NOTE: This is not automatically used but must be added to the template in sasl.kerberos.kinit.cmd as ... -t %{sasl.kerberos.keytab}. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "sasl.kerberos.keytab")]
        public string SASLKerberosKeytab { get; set; }

        /// <summary>
        /// Minimum time in milliseconds between key refresh attempts. 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "sasl.kerberos.min.time.before.relogin")]
        public int SASLKerberosMinTimeBeforeRelogin { get; set; }

        /// <summary>
        /// SASL username for use with the PLAIN and SASL-SCRAM-.. mechanisms 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "sasl.username")]
        public string SASLUsername { get; set; }

        /// <summary>
        /// SASL password for use with the PLAIN and SASL-SCRAM-.. mechanism 
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "sasl.password")]
        public string SASLPassword { get; set; }

        /// <summary>
        /// SASL/OAUTHBEARER configuration. The format is implementation-dependent and must be parsed accordingly. The default unsecured token implementation (see https://tools.ietf.org/html/rfc7515#appendix-A.5) recognizes space-separated name=value pairs with valid names including principalClaimName, principal, scopeClaimName, scope, and lifeSeconds. The default value for principalClaimName is "sub", the default value for scopeClaimName is "scope", and the default value for lifeSeconds is 3600. The scope value is CSV format with the default value being no/empty scope. For example: principalClaimName=azp principal=admin scopeClaimName=roles scope=role1,role2 lifeSeconds=600. In addition, SASL extensions can be communicated to the broker via extension_[extensionname]=value. For example: principal=admin extension_traceId=123
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "sasl.oauthbearer.config")]
        public string SASLOauthbearerConfig { get; set; }

        /// <summary>
        /// List of plugin libraries to load (; separated). The library search path is platform dependent (see dlopen(3) for Unix and LoadLibrary() for Windows). If no filename extension is specified the platform-specific extension (such as .dll or .so) will be appended automatically.
        /// </summary>
        [KafkaConfiguration(KafkaPropertyName = "plugin.library.paths")]
        public string PluginLibraryPaths { get; set; }
    }
}
