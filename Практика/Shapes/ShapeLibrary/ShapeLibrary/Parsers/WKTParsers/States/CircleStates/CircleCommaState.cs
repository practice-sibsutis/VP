using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.WKTParsers.States.CircleStates;
using ShapeLibrary.Parsers.WKTParsers.Contexts;
using ShapeLibrary.Parsers.WKTParsers.States.BaseStates;

namespace ShapeLibrary.Parsers.WKTParsers.States.CircleStates;

public class CircleCommaState : CharacterState
{
    public CircleCommaState() : base(',') { }

    protected override void ChangeState(IContext context)
    {
        context.State = new CircleRadiusState();
    }
}