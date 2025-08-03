using System.Windows.Controls;
using System.Windows.Media;
using WSCAD.Core;
using WSCAD.Core.Models;

namespace WSCAD_Code_Challenge.Drawing
{
    public class ShapeDrawingService : IShapeDrawingService
    {
        private const double MARGIN = 50;
        private readonly IEnumerable<IShapeRenderer> _renderers;

        public ShapeDrawingService(IEnumerable<IShapeRenderer> renderers)
        {
            _renderers = renderers;
        }

        public void DrawShapes(IEnumerable<Shape> shapes, Canvas canvas)
        {
            canvas.Children.Clear();

            foreach (var shape in shapes)
            {
                var renderer = _renderers.FirstOrDefault(r => r.CanRender(shape));
                renderer?.Render(shape, canvas);
            }

            var boundingBox = CalculateBoundingBox(shapes);

            double scaleX = (canvas.ActualWidth - 2 * MARGIN) / boundingBox.Width;
            double scaleY = (canvas.ActualHeight - 2 * MARGIN) / boundingBox.Height;
            double scale = Math.Min(scaleX, scaleY);

            double offsetX = -boundingBox.MinX * scale + MARGIN;
            double offsetY = -boundingBox.MinY * scale + MARGIN;

            var tg = new TransformGroup();
            tg.Children.Add(new ScaleTransform(scale, -scale));
            tg.Children.Add(new TranslateTransform(offsetX, canvas.ActualHeight - offsetY));
            canvas.RenderTransform = tg;
        }

        private static BoundingBox CalculateBoundingBox(IEnumerable<Shape> shapes)
        {
            var boxes = shapes.Select(s => s.GetBoundingBox()).ToList();

            double minX = boxes.Min(b => b.MinX);
            double minY = boxes.Min(b => b.MinY);
            double maxX = boxes.Max(b => b.MaxX);
            double maxY = boxes.Max(b => b.MaxY);

            return new BoundingBox(minX, minY, maxX, maxY);
        }
    }
}
