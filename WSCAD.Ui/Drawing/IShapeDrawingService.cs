using System.Windows.Controls;
using WSCAD.Core;

namespace WSCAD.Ui.Drawing
{
    public interface IShapeDrawingService
    {
        void DrawShapes(IEnumerable<Shape> shapes, Canvas canvas);
    }
}
