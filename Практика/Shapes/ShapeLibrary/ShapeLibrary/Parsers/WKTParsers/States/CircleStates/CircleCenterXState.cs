using ShapeLibrary.Parsers.WKTParsers.States.CircleStates;
using ShapeLibrary.Parsers.WKTParsers.Contexts;
using ShapeLibrary.Parsers.WKTParsers.States.BaseStates;

namespace ShapeLibrary.Parsers.WKTParsers.States.CircleStates;

public class CircleCenterXState : DoubleState
{
    protected override void ChangeState(IContext context)
    {
        if (context is CircleContext circleContext)
        {
            circleContext.CenterXStringRepresentation = NumberStringRepresentation;
        }

        context.State = new CircleCenterYState();
    }
}