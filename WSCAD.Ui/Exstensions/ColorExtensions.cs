using WSCAD.Core;

namespace WSCAD.Ui
{
    public static class ColorExtensions
    {
        public static System.Windows.Media.Color ToMediaColor(this Color color)
        {
            return System.Windows.Media.Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue);
        }
    }
}
