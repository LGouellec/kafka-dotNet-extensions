using Confluent.Kafka;
using System.IO;
using System.Text;

namespace kafka_dotNet_extensions_core.Serializer
{
    public class JsonObjectSerializer<TObject> : Confluent.Kafka.ISerializer<TObject>
    {
        private readonly Newtonsoft.Json.JsonSerializer _serializer = Newtonsoft.Json.JsonSerializer.Create();

        public byte[] Serialize(TObject data, SerializationContext context)
        {
            using (var stream = new MemoryStream())
            {
                var writer = new StreamWriter(stream, Encoding.UTF8);
                _serializer.Serialize(writer, data);
                writer.Flush();
                stream.Position = 0;
                return stream.ToArray();
            }
        }
    }
}
