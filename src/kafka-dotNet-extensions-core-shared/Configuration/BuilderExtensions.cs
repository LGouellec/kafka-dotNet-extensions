namespace kafka_dotNet_extensions_core
{
    public static class BuilderExtensions
    {
        public static IBuilder UseYamlConfigurationFile(this IBuilder builder, string pathYamlFile)
        {
            return builder;
        }
    }
}
