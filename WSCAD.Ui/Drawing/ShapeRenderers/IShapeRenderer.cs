using System.Windows.Controls;
using WSCAD.Core;

namespace WSCAD.Ui.Drawing
{
    public interface IShapeRenderer
    {
        bool CanRender(Shape shape);

        void Render(Shape shape, Canvas canvas);
    }
}
