using System.Text.Json;
using System.Text.Json.Serialization;
using WSCAD.Core;

namespace WSCAD.Infrastructure
{
    public class ShapeConverter : JsonConverter<Shape>
    {
        public override Shape Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;

            if (!root.TryGetProperty("type", out var typeProp))
            {
                throw new JsonException("Shape type property missing");
            }

            var type = typeProp.GetString();
            var json = root.GetRawText();

            return type switch
            {
                "line" => JsonSerializer.Deserialize<Line>(json, options),
                "circle" => JsonSerializer.Deserialize<Circle>(json, options),
                "triangle" => JsonSerializer.Deserialize<Triangle>(json, options),
                _ => throw new JsonException($"Unknown shape type: {type}")
            };
        }

        public override void Write(Utf8JsonWriter writer, Shape value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, options);
        }
    }
}
