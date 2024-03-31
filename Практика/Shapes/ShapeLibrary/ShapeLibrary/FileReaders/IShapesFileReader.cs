using ShapeLibrary.Shapes;

namespace ShapeLibrary.FileReaders;

public interface IShapesFileReader
{
    IEnumerable<IShape> ReadShapesFromFile(string filePath);
}