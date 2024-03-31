using ShapeLibrary.Shapes;

namespace ShapeLibrary.IntersectionCheckers.PairShapesIntersectionCheckers;

public interface IPairShapesIntersectionChecker
{
    bool IsIntersect(IShape first, IShape second);
    bool IsMatch(IShape first, IShape second);
}