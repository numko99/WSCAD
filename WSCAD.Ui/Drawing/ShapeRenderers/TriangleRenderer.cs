using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WSCAD.Core;
using Shape = WSCAD.Core.Shape;

namespace WSCAD.Ui.Drawing
{
    public class TriangleRenderer : IShapeRenderer
    {
        public bool CanRender(Shape shape) => shape is Triangle;

        public void Render(Shape shape, Canvas canvas)
        {
            var triangle = (Triangle)shape;

            var polygon = new Polygon
            {
                Stroke = new SolidColorBrush(triangle.Color.ToMediaColor()),
                StrokeThickness = 1,
                Points = new PointCollection
            {
                new System.Windows.Point(triangle.A.X, triangle.A.Y),
                new System.Windows.Point(triangle.B.X, triangle.B.Y),
                new System.Windows.Point(triangle.C.X, triangle.C.Y)
            }
            };

            if (triangle.Filled)
                polygon.Fill = new SolidColorBrush(triangle.Color.ToMediaColor());

            canvas.Children.Add(polygon);
        }
    }
}
