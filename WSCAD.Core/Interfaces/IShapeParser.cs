namespace WSCAD.Core
{
    public interface IShapeParser
    {
        List<Shape> Parse(string content);

        bool CanParse(string fileExtension);
    }
}
