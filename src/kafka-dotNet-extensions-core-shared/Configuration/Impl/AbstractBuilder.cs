using kafka_dotNet_extensions_core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace kafka_dotNet_extensions_core.Configuration
{
    public abstract class AbstractBuilder<TKey, TValue> : IBuilder<TKey, TValue>
    {
        protected readonly Dictionary<string, object> _configuration = new Dictionary<string, object>();
        protected readonly List<string> _brokerList = new List<string>();
        protected string[] _topics;
        protected bool _subscribeOnBuild = false;

        public IBuilder AddBroker(string broker)
        {
            if (string.IsNullOrEmpty(broker))
                throw new ArgumentNullException(nameof(broker));

            return this.AddBrokers(broker);
        }

        public IBuilder AddBrokers(params string[] brokers)
        {
            _brokerList.AddRange(brokers);
            return this;
        }

        public IBuilder SetCliendId(string cliendId)
        {
            if (string.IsNullOrEmpty(cliendId))
                throw new ArgumentNullException(nameof(cliendId));

            _configuration["client.id"] = cliendId;
            return this;
        }

        public IBuilder WithGroupId(string groupId)
        {
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentNullException(nameof(groupId));

            _configuration["group.id"] = groupId;
            return this;
        }

        public IBuilder ForTopics(params string[] topics)
        {
            if (topics != null)
                _topics = topics;
            return this;
        }

        public IBuilder UseGeneralProperties(GeneralProperties properties)
        {
            ApplyParameters(properties);
            return this;
        }

        public IBuilder UseTopicProperties(TopicProperties properties)
        {
            ApplyParameters(properties);
            return this;
        }

        #region Abstract
        public abstract IBuilder UseConsumerProperties(ConsumerProperties properties);

        public abstract IBuilder UseProducerProperties(ProducerProperties properties);
        #endregion

        protected void ApplyParameters(object properties)
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(properties))
            {
                AttributeCollection attributes = property.Attributes;
                KafkaConfigurationAttribute kafkaValueAttribute = (KafkaConfigurationAttribute)attributes[typeof(KafkaConfigurationAttribute)];
                if (kafkaValueAttribute != null)
                {
                    object value = property.GetValue(properties);
                    if((!(value is string) && value != null) || (value is string && !String.IsNullOrEmpty(value.ToString())))
                        _configuration[kafkaValueAttribute.KafkaPropertyName] = value;
                }   
            }
        }
    }
}
