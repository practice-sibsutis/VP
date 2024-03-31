using ShapeLibrary.Parsers.WKTParsers.Contexts;

namespace ShapeLibrary.Parsers.WKTParsers.States.BaseStates;

public interface IState
{
    void Processing(IContext context);
}