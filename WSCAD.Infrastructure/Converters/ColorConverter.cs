using System.Text.Json;
using System.Text.Json.Serialization;
using WSCAD.Core;

namespace WSCAD.Infrastructure
{
    public class ColorConverter : JsonConverter<Color>
    {
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            var parts = value.Split(';', StringSplitOptions.TrimEntries);

            if (parts.Length != 4)
            {
                throw new JsonException("Invalid color format");
            }

            return new Color
            {
                Alpha = byte.Parse(parts[0]),
                Red = byte.Parse(parts[1]),
                Green = byte.Parse(parts[2]),
                Blue = byte.Parse(parts[3])
            };
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value.Alpha}; {value.Red}; {value.Green}; {value.Blue}");
        }
    }
}