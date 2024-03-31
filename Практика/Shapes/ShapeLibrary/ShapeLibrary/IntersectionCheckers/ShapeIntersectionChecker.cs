using ShapeLibrary.IntersectionCheckers.PairShapesIntersectionCheckers;
using ShapeLibrary.Shapes;

namespace ShapeLibrary.IntersectionCheckers;

public class ShapeIntersectionChecker : IShapesIntersectionChecker
{
    public ShapeIntersectionChecker(IEnumerable<IPairShapesIntersectionChecker> shapesIntersectionCheckers)
    {
        _shapesIntersectionCheckers = shapesIntersectionCheckers;
    }
    public bool IsIntersect(IShape firstShape, IShape secondShape)
    {
        return _shapesIntersectionCheckers.
            First(checker => checker.IsMatch(firstShape, secondShape))
            .IsIntersect(firstShape, secondShape);
    }

    private IEnumerable<IPairShapesIntersectionChecker> _shapesIntersectionCheckers;
}