using ShapeLibrary.Parsers.BaseParsers;
using ShapeLibrary.Shapes;

namespace ShapeLibrary.FileReaders.WKTFileReaders;

public class WktShapesFileReader : IShapesFileReader
{
    public WktShapesFileReader(IShapeParser shapeParser)
    {
        _shapeParser = shapeParser;
    }
    public IEnumerable<IShape> ReadShapesFromFile(string filePath)
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
           List<IShape> shapes = new List<IShape>();

           while (sr.EndOfStream == false)
           {
                string? shapeStringRepresentation = sr.ReadLine();

                if (string.IsNullOrEmpty(shapeStringRepresentation) == false ||
                    string.IsNullOrWhiteSpace(shapeStringRepresentation) == false)
                {
                    shapes.Add(_shapeParser.Parse(shapeStringRepresentation));
                }
           }

           return shapes;
        }
    }

    private IShapeParser _shapeParser;
}