using System.Globalization;
using ShapeLibrary.Parsers.WKTParsers.States.CircleStates;
using ShapeLibrary.Parsers.BaseParsers;
using ShapeLibrary.Shapes;
using ShapeLibrary.Parsers.WKTParsers.Contexts;
using ShapeLibrary.Parsers.WKTParsers.States.BaseStates;

namespace ShapeLibrary.Parsers.WKTParsers.ShapeParsers;

public class CircleWktParser : IShapeParser
{
    public IShape Parse(string shapeStringRepresentation)
    {
        IState state = new CircleStartWordState();
        CircleContext context = new CircleContext(shapeStringRepresentation, state);

        do
        {
            state.Processing(context);
            state = context.State;
        } while (state is not CircleEndState);

        state.Processing(context);

        double centerX = double.Parse(context.CenterXStringRepresentation,
            new NumberFormatInfo { NumberDecimalSeparator = "." });

        double centerY = double.Parse(context.CenterYStringRepresentation,
            new NumberFormatInfo { NumberDecimalSeparator = "." });

        double radius = double.Parse(context.RadiusStringRepresentation,
            new NumberFormatInfo { NumberDecimalSeparator = "." });

        return new Circle(new Point(centerX, centerY), radius);
    }
}