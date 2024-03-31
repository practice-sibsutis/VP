using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.WKTParsers.Contexts;
using ShapeLibrary.Parsers.WKTParsers.States.BaseStates;

namespace ShapeLibrary.Parsers.WKTParsers.States.CircleStates;

public class CircleEndState : BaseState
{
    protected override void CheckMatching(IContext context)
    {
        if (context.Position < context.ShapeStringRepresentation.Length)
        {
            throw new InvalidCharacterExeption(
                context.ShapeStringRepresentation,
                context.Position, "End of string");
        }
    }

    protected override void ChangeState(IContext context)
    {

    }
}