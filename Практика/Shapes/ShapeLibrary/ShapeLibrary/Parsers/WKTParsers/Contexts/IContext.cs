using ShapeLibrary.Parsers.WKTParsers.States.BaseStates;

namespace ShapeLibrary.Parsers.WKTParsers.Contexts;

public interface IContext
{
    public string ShapeStringRepresentation { get; }
    public IState State { get; set; }
    int Position { get; set; }
}