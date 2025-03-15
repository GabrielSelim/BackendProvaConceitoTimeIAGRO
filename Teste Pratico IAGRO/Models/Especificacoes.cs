using System.Text.Json;
using System.Text.Json.Serialization;

namespace Teste_Pratico_IAGRO.Models
{
    public class Especificacoes
    {
        public string OriginallyPublished { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Illustrator { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<string>))]
        public List<string> Genres { get; set; }
    }

    public class SingleOrArrayConverter<T> : JsonConverter<List<T>>
    {
        public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                return JsonSerializer.Deserialize<List<T>>(ref reader, options);
            }

            var value = JsonSerializer.Deserialize<T>(ref reader, options);
            return new List<T> { value };
        }

        public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}