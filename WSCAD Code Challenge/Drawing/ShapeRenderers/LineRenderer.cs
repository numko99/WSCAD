using System.Windows.Controls;
using System.Windows.Media;
using WSCAD.Core;

namespace WSCAD_Code_Challenge.Drawing
{
    public class LineRenderer : IShapeRenderer
    {
        public bool CanRender(Shape shape) => shape is Line;

        public void Render(Shape shape, Canvas canvas)
        {
            var line = (Line)shape;

            var lineShape = new System.Windows.Shapes.Line
            {
                X1 = line.A.X,
                Y1 = line.A.Y,
                X2 = line.B.X,
                Y2 = line.B.Y,
                Stroke = new SolidColorBrush(line.Color.ToMediaColor()),
                StrokeThickness = 2
            };

            canvas.Children.Add(lineShape);
        }
    }
}
