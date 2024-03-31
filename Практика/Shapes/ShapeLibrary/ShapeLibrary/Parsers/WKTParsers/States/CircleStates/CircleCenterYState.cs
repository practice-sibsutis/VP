using ShapeLibrary.Parsers.WKTParsers.States.CircleStates;
using ShapeLibrary.Parsers.WKTParsers.Contexts;
using ShapeLibrary.Parsers.WKTParsers.States.BaseStates;

namespace ShapeLibrary.Parsers.WKTParsers.States.CircleStates;

public class CircleCenterYState : DoubleState
{
    protected override void ChangeState(IContext context)
    {
        if (context is CircleContext circleContext)
        {
            circleContext.CenterYStringRepresentation = NumberStringRepresentation;
        }

        context.State = new CircleCommaState();
    }
}