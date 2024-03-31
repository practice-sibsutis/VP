using ShapeLibrary.Shapes;

namespace ShapeLibrary.IntersectionCheckers;

public interface IShapesIntersectionChecker
{
    bool IsIntersect(IShape firstShape, IShape secondShape);
}