using kafka_dotNet_extensions_core;

namespace kafka_dotNet_extensions_core
{
    /// <summary>
    /// 
    /// </summary>
    public static class BuilderFKExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="topic"></param>
        /// <returns></returns>
        public static IBuilder UseSectionConfiguration(this IBuilder builder, string topic)
        {
            return builder;
        }
    }
}
