namespace kafka_dotNet_extensions_core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliendId"></param>
        /// <returns></returns>
        IBuilder SetCliendId(string cliendId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="broker"></param>
        /// <returns></returns>
        IBuilder AddBroker(string broker);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brokers"></param>
        /// <returns></returns>
        IBuilder AddBrokers(params string[] brokers);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        IBuilder WithGroupId(string groupId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        IBuilder ForTopics(params string[] topic);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        IBuilder UseGeneralProperties(GeneralProperties properties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        IBuilder UseConsumerProperties(ConsumerProperties properties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        IBuilder UseProducerProperties(ProducerProperties properties);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        IBuilder UseTopicProperties(TopicProperties properties);
    }
}
