using ShapeLibrary.Exeptions;
using ShapeLibrary.IntersectionCheckers;
using ShapeLibrary.Parsers.BaseParsers;
using ShapeLibrary.Parsers.WKTParsers.ShapeParsers;
using ShapeLibrary.Shapes;

namespace ShapeMain.RunningModes;

public class InteractiveRunningMode : BaseRunningMode
{
    public InteractiveRunningMode(IShapeParser shapesParser, IShapesIntersectionChecker shapesIntersectionChecker)
    {
        _shapesParser = shapesParser;
        _sr = new StreamReader(Console.OpenStandardInput());
        _shapesIntersectionChecker = shapesIntersectionChecker;
        _shapes = new List<IShape>();
    }

    public override void Run()
    {
        string? circleStringRepresentation = _sr.ReadLine();

        while (string.IsNullOrEmpty(circleStringRepresentation) == false &&
               string.IsNullOrWhiteSpace(circleStringRepresentation) == false)
        {
            IShape shape;

            try
            {
                shape = _shapesParser.Parse(circleStringRepresentation);
            }
            catch (InvalidCharacterExeption ex)
            {
                PrintError(ex);
                return;
            }
            Console.WriteLine($"{shape}");
            Console.WriteLine($"Perimeter {shape.Perimeter}");
            Console.WriteLine($"Square {shape.Square}");
            PrintIntersect(shape, _shapes, _shapesIntersectionChecker);
            Console.WriteLine();

            _shapes.Add(shape);

            circleStringRepresentation = _sr.ReadLine();
        }
    }

    private IShapeParser _shapesParser;
    private IShapesIntersectionChecker _shapesIntersectionChecker;
    private StreamReader _sr;
    private List<IShape> _shapes;
}