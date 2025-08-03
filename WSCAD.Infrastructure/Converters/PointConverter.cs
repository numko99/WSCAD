using System.Text.Json;
using System.Text.Json.Serialization;
using WSCAD.Core;

namespace WSCAD.Infrastructure
{
    public class PointConverter : JsonConverter<Point>
    {
        public override Point Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            var parts = value.Split(';', StringSplitOptions.TrimEntries);

            if (parts.Length != 2)
            {
                throw new JsonException("Invalid point format");
            }

            return new Point
            {
                X = double.Parse(parts[0]),
                Y = double.Parse(parts[1])
            };
        }

        public override void Write(Utf8JsonWriter writer, Point value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value.X}; {value.Y}");
        }
    }
}