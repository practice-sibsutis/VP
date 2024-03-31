using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.WKTParsers.Contexts;
using ShapeLibrary.Parsers.WKTParsers.States.BaseStates;

namespace ShapeLibrary.Parsers.WKTParsers.States.CircleStates;

public class CircleOpenBracketState : CharacterState
{
    public CircleOpenBracketState() : base('(') { }

    protected override void ChangeState(IContext context)
    {
        context.State = new CircleCenterXState();
    }
}