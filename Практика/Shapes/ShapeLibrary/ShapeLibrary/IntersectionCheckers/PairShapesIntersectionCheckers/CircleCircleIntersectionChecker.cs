using ShapeLibrary.Shapes;

namespace ShapeLibrary.IntersectionCheckers.PairShapesIntersectionCheckers;

public class CircleCircleIntersectionChecker : IPairShapesIntersectionChecker
{
    public bool IsIntersect(IShape firstShape, IShape secondShape)
    {
        if (firstShape is Circle firstCircle &&
            secondShape is Circle secondCircle)
        {
            double xSub = firstCircle.Center.X - secondCircle.Center.X;
            double xSqr = xSub * xSub;

            double ySub = firstCircle.Center.Y - secondCircle.Center.Y;
            double ySqr = ySub * ySub;

            double len = Math.Sqrt(xSqr + ySqr);

            return len <= firstCircle.Radius + secondCircle.Radius;
        }

        return false;
    }

    public bool IsMatch(IShape firstShape, IShape secondShape)
    {
        return firstShape is Circle && secondShape is Circle;
    }
}