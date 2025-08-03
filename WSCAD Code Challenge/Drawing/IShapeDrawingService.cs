using System.Windows.Controls;
using WSCAD.Core;

namespace WSCAD_Code_Challenge.Drawing
{
    public interface IShapeDrawingService
    {
        void DrawShapes(IEnumerable<Shape> shapes, Canvas canvas);
    }
}
