using System.Globalization;

namespace ShapeLibrary.Shapes;

public struct Point
{
    public Point(double x, double y)
    {
        _x = x;
        _y = y;
    }

    public override string ToString()
    {
        return $"{_x.ToString(new NumberFormatInfo { CurrencyDecimalSeparator = "." })}" +
               $" {_y.ToString(new NumberFormatInfo { CurrencyDecimalSeparator = "." })}";
    }

    public double X => _x;
    public double Y => _y;

    private double _x;
    private double _y;
}