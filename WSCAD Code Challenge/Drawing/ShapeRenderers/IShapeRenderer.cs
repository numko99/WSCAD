using System.Windows.Controls;
using WSCAD.Core;

namespace WSCAD_Code_Challenge.Drawing
{
    public interface IShapeRenderer
    {
        bool CanRender(Shape shape);

        void Render(Shape shape, Canvas canvas);
    }
}
