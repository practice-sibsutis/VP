using ShapeLibrary.Exeptions;
using ShapeLibrary.FileReaders;
using ShapeLibrary.IntersectionCheckers;
using ShapeLibrary.Parsers.WKTParsers.ShapeParsers;
using ShapeLibrary.Shapes;

namespace ShapeMain.RunningModes;

public class ProcessingFileRunningMode : BaseRunningMode
{
    public ProcessingFileRunningMode(IShapesFileReader shapesFileReader,
        IShapesIntersectionChecker shapesIntersectionChecker,
        string filePath)
    {
        _shapesFileReader = shapesFileReader;
        _sr = new StreamReader(Console.OpenStandardInput());
        _shapesIntersectionChecker = shapesIntersectionChecker;
        _filePath = filePath;
    }
    public override void Run()
    {
        IEnumerable<IShape> _shapes = new List<IShape>();

        try
        {
            _shapes = _shapesFileReader.ReadShapesFromFile(_filePath);
        }
        catch (InvalidCharacterExeption ex)
        {
            PrintError(ex);
            return;
        }

        foreach (IShape shape in _shapes)
        {
            Console.WriteLine($"{shape}");
            Console.WriteLine($"Perimeter {shape.Perimeter}");
            Console.WriteLine($"Square {shape.Square}");
            PrintIntersect(shape, _shapes, _shapesIntersectionChecker);
            Console.WriteLine();
        }
        
    }

    private IShapesFileReader _shapesFileReader;
    private IShapesIntersectionChecker _shapesIntersectionChecker;
    private StreamReader _sr;
    private string _filePath;
}