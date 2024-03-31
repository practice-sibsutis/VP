using System.Globalization;

namespace ShapeLibrary.Shapes;

public class Circle : IShape
{
    public Circle(Point center, double radius)
    {
        _center = center;
        _radius = radius;
    }

    public override string ToString()
    {
        return $"circle({_center}, " +
               $"{_radius.ToString(new NumberFormatInfo{CurrencyDecimalSeparator = "."})})";
    }

    public double Square => Radius * Radius * Math.PI;
    public double Perimeter => Radius * 2 * Math.PI;

    public Point Center => _center;
    public double Radius => _radius;

    private Point _center;
    private double _radius;
}