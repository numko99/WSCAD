using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WSCAD.Core;
using Shape = WSCAD.Core.Shape;

namespace WSCAD.Ui.Drawing
{
    public class CircleRenderer : IShapeRenderer
    {
        public bool CanRender(Shape shape) => shape is Circle;

        public void Render(Shape shape, Canvas canvas)
        {
            var circle = (Circle)shape;

            var ellipse = new Ellipse
            {
                Width = circle.Radius * 2,
                Height = circle.Radius * 2,
                Stroke = new SolidColorBrush(circle.Color.ToMediaColor()),
                StrokeThickness = 1
            };

            if (circle.Filled)
            {
                ellipse.Fill = new SolidColorBrush(circle.Color.ToMediaColor());
            }

            Canvas.SetLeft(ellipse, circle.Center.X - circle.Radius);
            Canvas.SetTop(ellipse, circle.Center.Y - circle.Radius);
            canvas.Children.Add(ellipse);
        }
    }
}
