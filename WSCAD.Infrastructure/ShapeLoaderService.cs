using WSCAD.Core;

namespace WSCAD.Infrastructure
{
    public class ShapeLoaderService : IShapeLoaderService
    {
        private readonly IEnumerable<IShapeParser> _parsers;

        public ShapeLoaderService(IEnumerable<IShapeParser> parsers)
        {
            _parsers = parsers;
        }

        public List<Shape> LoadShapesFromFile(string filePath)
        {
            var fileExtension = Path.GetExtension(filePath);
            var parser = _parsers.FirstOrDefault(p => p.CanParse(fileExtension));

            if (parser == null)
            {
                throw new NotSupportedException($"File format {fileExtension} is not supported");
            }

            var content = File.ReadAllText(filePath);
            return parser.Parse(content);
        }
    }
}
