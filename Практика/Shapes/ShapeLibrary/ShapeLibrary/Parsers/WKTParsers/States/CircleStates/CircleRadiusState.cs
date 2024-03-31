using ShapeLibrary.Parsers.WKTParsers.Contexts;
using ShapeLibrary.Parsers.WKTParsers.States.BaseStates;

namespace ShapeLibrary.Parsers.WKTParsers.States.CircleStates;

public class CircleRadiusState : DoubleState
{
    protected override void ChangeState(IContext context)
    {
        if (context is CircleContext circleContext)
        {
            circleContext.RadiusStringRepresentation = NumberStringRepresentation;
        }

        context.State = new CircleCloseBracketState();
    }
}