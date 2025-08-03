namespace WSCAD.Core.Models
{
    public class BoundingBox
    {
        public double MinX { get; }

        public double MinY { get; }

        public double MaxX { get; }

        public double MaxY { get; }

        public BoundingBox(double minX, double minY, double maxX, double maxY)
        {
            MinX = minX;
            MinY = minY;
            MaxX = maxX;
            MaxY = maxY;
        }

        public double Width => MaxX - MinX;

        public double Height => MaxY - MinY;
    }
}
