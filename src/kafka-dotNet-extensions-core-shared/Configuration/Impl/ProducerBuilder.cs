namespace kafka_dotNet_extensions_core.Configuration
{
    public class ProducerBuilder<TKey, TValue> : AbstractBuilder
    {
        public override IBuilder UseConsumerProperties(ConsumerProperties properties)
        {
            return this;
        }

        public override IBuilder UseProducerProperties(ProducerProperties properties)
        {
            ApplyParameters(properties);
            return this;
        }
    }
}
