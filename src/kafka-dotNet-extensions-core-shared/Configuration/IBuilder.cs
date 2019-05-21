namespace kafka_dotNet_extensions_core
{
    public interface IBuilder
    {
        IBuilder SetCliendId(string cliendId);
        IBuilder AddBroker(string broker);
        IBuilder AddBrokers(params string[] brokers);
        IBuilder WithGroupId(string groupId);
        IBuilder UseGeneralProperties(GeneralProperties properties);
        IBuilder UseConsumerProperties(ConsumerProperties properties);
        IBuilder UseProducerProperties(ProducerProperties properties);
        IBuilder UseTopicProperties(TopicProperties properties);

        //message.max.bytes
        //message.copy.max.bytes
        //receive.message.max.bytes
        //        max.in.flight.requests.per.connection
        //            max.in.flight
        //            metadata.request.timeout.ms
        //            topic.metadata.refresh.interval.ms
        //            metadata.max.age.ms
        //            topic.metadata.refresh.fast.interval.ms
        //            topic.metadata.refresh.fast.cnt
        //            topic.metadata.refresh.sparse
        //            topic.blacklist
        //            debug
        //            socket.timeout.ms
        //            socket.blocking.max.ms
        //            socket.send.buffer.bytes
        //            socket.receive.buffer.bytes
        //            socket.keepalive.enable
        //            socket.nagle.disable
        //            socket.max.fails
        //            broker.address.ttl
        //            broker.address.family
        //            reconnect.backoff.jitter.ms
        //            reconnect.backoff.ms
        //            reconnect.backoff.max.ms
        //            statistics.interval.ms
        //            enabled_events
        //            error_cb
        //            throttle_cb
        //            stats_cb
        //            log_cb
        //            oauthbearer_token_refresh_cb
        //            log_level
        //            log.queue
        //            log.thread.name
        //            log.connection.close
        //            security.protocol
        //            ssl.cipher.suites
        //            ssl.curves.list
        //            ssl.sigalgs.list
        //            ssl.key.location
        //            ssl.key.password
        //            ssl.certificate.location
        //            ssl.ca.location
        //            ssl.crl.location
        //            ssl.keystore.location
        //            ssl.keystore.password
        //            sasl.mechanism
        //            sasl.kerberos.service.name
        //            sasl.kerberos.principal
        //            sasl.kerberos.kinit.cmd
        //            sasl.kerberos.keytab
        //            sasl.kerberos.min.time.before.relogin
        //            sasl.username
        //            sasl.password
        //            sasl.oauthbearer.config
        //            plugin.library.paths

        //            // C
        //                   
        //            partition.assignment.strategy
        //session.timeout.ms
        //            heartbeat.interval.ms
        //            group.protocol.type
        //            coordinator.query.interval.ms
        //            max.poll.interval.ms
        //            enable.auto.commit
        //            auto.commit.interval.ms
        //            enable.auto.offset.store
        //            queued.min.messages
        //            queued.max.messages.kbytes
        //            fetch.wait.max.ms
        //            fetch.message.max.bytes
        //            max.partition.fetch.bytes
        //            fetch.max.bytes
        //            fetch.min.bytes
        //            fetch.error.backoff.ms
        //            offset.store.method
        //            enable.partition.eof
        //            check.crcs

        //            // P
        //            enable.idempotence
        //            enable.gapless.guarantee
        //            queue.buffering.max.messages
        //            queue.buffering.max.kbytes
        //            queue.buffering.max.ms
        //            linger.ms
        //            message.send.max.retries
        //            retries
        //            retry.backoff.ms
        //            queue.buffering.backpressure.threshold
        //            compression.codec
        //            compression.type
        //            batch.num.messages
        //            delivery.report.only.error

        //            // Topic conf
        //            acks
        //            request.timeout.ms
        //            message.timeout.ms
        //            delivery.timeout.ms
        //            partitioner
        //            compression.level
        //            auto.offset.reset
    }
}
