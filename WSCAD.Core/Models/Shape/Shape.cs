using System.Text.Json.Serialization;
using WSCAD.Core.Models;

namespace WSCAD.Core
{
    public abstract class Shape
    {
        [JsonPropertyName("type")]
        public abstract string Type { get; }


        [JsonPropertyName("color")]
        public Color Color { get; set; }


        [JsonPropertyName("filled")]
        public bool Filled { get; set; }

        public abstract BoundingBox GetBoundingBox();
    }
}
