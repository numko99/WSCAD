using System.Text.Json.Serialization;
using WSCAD.Core.Models;

namespace WSCAD.Core
{
    public class Triangle : Shape
    {
        public override string Type => "triangle";

        
        [JsonPropertyName("a")]
        public Point A { get; set; }

        
        [JsonPropertyName("b")]
        public Point B { get; set; }

        
        [JsonPropertyName("c")]
        public Point C { get; set; }

        public override BoundingBox GetBoundingBox()
        {
            double minX = Math.Min(A.X, Math.Min(B.X, C.X));
            double minY = Math.Min(A.Y, Math.Min(B.Y, C.Y));
            double maxX = Math.Max(A.X, Math.Max(B.X, C.X));
            double maxY = Math.Max(A.Y, Math.Max(B.Y, C.Y));

            return new BoundingBox(minX, minY, maxX, maxY);
        }
    }
}
