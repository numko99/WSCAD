using System.Text.Json;
using WSCAD.Core;

namespace WSCAD.Infrastructure
{
    public class JsonShapeParser : IShapeParser
    {
        private readonly JsonSerializerOptions _options;

        public JsonShapeParser()
        {
            _options = new JsonSerializerOptions
            {
                Converters = { new ShapeConverter(), new PointConverter(), new ColorConverter() },
                PropertyNameCaseInsensitive = true
            };
        }

        public List<Shape> Parse(string content)
        {
            return JsonSerializer.Deserialize<List<Shape>>(content, _options);
        }

        public bool CanParse(string fileExtension)
        {
            return fileExtension.Equals(".json", StringComparison.OrdinalIgnoreCase);
        }
    }
}
