using ShapeLibrary.Parsers.WKTParsers.Contexts;

namespace ShapeLibrary.Parsers.WKTParsers.States.BaseStates;

public abstract class BaseState : IState
{
    public virtual void Processing(IContext context)
    {
        SkipWhiteSpace(context);
        CheckMatching(context);
        SkipWhiteSpace(context);
        ChangeState(context);
    }

    protected abstract void CheckMatching(IContext context);
    protected abstract void ChangeState(IContext context);

    protected virtual void SkipWhiteSpace(IContext context)
    {
        while (context.Position < context.ShapeStringRepresentation.Length &&
               context.ShapeStringRepresentation[context.Position] == ' ')
        {
            ++context.Position;
        }
    }
}