using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.WKTParsers.Contexts;
using ShapeLibrary.Parsers.WKTParsers.States.BaseStates;
using ShapeLibrary.Shapes;

namespace ShapeLibrary.Parsers.WKTParsers.States.CircleStates;

public class CircleStartWordState : StringState
{
    public CircleStartWordState() : base("circle")
    { }

    protected override void ChangeState(IContext context)
    {
        context.State = new CircleOpenBracketState();
    }
}