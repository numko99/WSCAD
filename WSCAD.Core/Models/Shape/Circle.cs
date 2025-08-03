using System.Text.Json.Serialization;
using WSCAD.Core.Models;

namespace WSCAD.Core
{
    public class Circle : Shape
    {
        public override string Type => "circle";

        
        [JsonPropertyName("center")]
        public Point Center { get; set; }

        
        [JsonPropertyName("radius")]
        public double Radius { get; set; }

        public override BoundingBox GetBoundingBox()
        {
            return new BoundingBox(
                Center.X - Radius,
                Center.Y - Radius,
                Center.X + Radius,
                Center.Y + Radius);
        }
    }
}
