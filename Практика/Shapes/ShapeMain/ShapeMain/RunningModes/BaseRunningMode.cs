using ShapeLibrary.Exeptions;
using ShapeLibrary.IntersectionCheckers;
using ShapeLibrary.Shapes;
using System.Text;

namespace ShapeMain.RunningModes;

public abstract class BaseRunningMode
{
    public abstract void Run();
    protected virtual void PrintError(InvalidCharacterExeption ex)
    {
        Console.WriteLine($"Invalid character at {ex.Position} expected {ex.Expected}:");
        Console.WriteLine(ex.StringRepresentation);

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < ex.Position; i++)
        {
            sb.Append('-');
        }

        sb.Append('^');

        Console.WriteLine(sb.ToString());
    }

    protected virtual void PrintIntersect(IShape shape, IEnumerable<IShape> shapes,
        IShapesIntersectionChecker shapesIntersectionChecker)
    {
        List<IShape> intersectsShapes = shapes.
            Where(s => shapesIntersectionChecker.IsIntersect(s, shape) && s != shape).ToList();

        if (intersectsShapes.Count > 0)
        {
            Console.WriteLine("Intersections:");
        }
        else
        {
            Console.WriteLine("Intersections: None");
        }

        foreach (IShape intersectsShape in intersectsShapes)
        {
            Console.WriteLine($"   {intersectsShape}");
        }
    }
}