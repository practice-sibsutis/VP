using ShapeLibrary.Parsers.WKTParsers.States.BaseStates;

namespace ShapeLibrary.Parsers.WKTParsers.Contexts;

public class CircleContext : IContext
{
    public CircleContext(string shapeStringRepresentation, IState startState)
    {
        _shapeStringRepresentation = shapeStringRepresentation;
        _state = startState;
        _position = 0;
    }

    public string ShapeStringRepresentation => _shapeStringRepresentation;

    public IState State
    {
        get => _state;
        set => _state = value;
    }

    public string RadiusStringRepresentation { get; set; } = string.Empty;
    public string CenterXStringRepresentation { get; set; } = string.Empty;
    public string CenterYStringRepresentation { get; set; } = string.Empty;

    public int Position
    {
        get => _position;
        set => _position = value;
    }

    private string _shapeStringRepresentation;
    private int _position;
    private IState _state;

}