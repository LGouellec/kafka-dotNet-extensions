using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.IO;

namespace kafka_dotNet_extensions_core.Serializer
{
    public class JsonObjectDeserializer<TObject> : Confluent.Kafka.IDeserializer<TObject>
    {
        private readonly Newtonsoft.Json.JsonSerializer _serializer = Newtonsoft.Json.JsonSerializer.Create();

        public TObject Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            using (var stream = new MemoryStream(data.ToArray()))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    using (JsonReader reader = new JsonTextReader(sr))
                    {
                        return _serializer.Deserialize<TObject>(reader);
                    }
                }
            }
        }
    }
}
