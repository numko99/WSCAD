namespace WSCAD.Core
{
    public interface IShapeLoaderService
    {
        List<Shape> LoadShapesFromFile(string filePath);
    }
}
