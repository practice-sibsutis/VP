using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.WKTParsers.Contexts;

namespace ShapeLibrary.Parsers.WKTParsers.States.BaseStates;

public abstract class StringState : BaseState
{
    public StringState(string inputString)
    {
        _inputString = inputString;
    }

    protected override void CheckMatching(IContext context)
    {
        foreach (char c in _inputString)
        {
            if (context.Position >= context.ShapeStringRepresentation.Length)
            {
                throw new InvalidCharacterExeption(
                    context.ShapeStringRepresentation,
                    context.Position, $"\'{_inputString}\'");
            }

            if (context.ShapeStringRepresentation[context.Position]
                    .ToString()
                    .ToLower()
                    .Equals(c.ToString()) == false)
            {
                throw new InvalidCharacterExeption(
                    context.ShapeStringRepresentation,
                    context.Position, $"\'{_inputString}\'");
            }

            ++context.Position;
        }
    }

    protected abstract override void ChangeState(IContext context);

    private string _inputString;
}