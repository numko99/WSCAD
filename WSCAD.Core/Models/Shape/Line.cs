using System.Text.Json.Serialization;
using WSCAD.Core.Models;

namespace WSCAD.Core
{
    public class Line : Shape
    {
        public override string Type => "line";

        
        [JsonPropertyName("a")]
        public Point A { get; set; }


        [JsonPropertyName("b")]
        public Point B { get; set; }

        public override BoundingBox GetBoundingBox()
        {
            double minX = Math.Min(A.X, B.X);
            double minY = Math.Min(A.Y, B.Y);
            double maxX = Math.Max(A.X, B.X);
            double maxY = Math.Max(A.Y, B.Y);
            return new BoundingBox(minX, minY, maxX, maxY);
        }
    }
}
