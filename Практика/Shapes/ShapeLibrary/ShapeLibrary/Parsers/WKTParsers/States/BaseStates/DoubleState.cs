using System.Text;
using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.WKTParsers.Contexts;

namespace ShapeLibrary.Parsers.WKTParsers.States.BaseStates;

public abstract class DoubleState : BaseState
{
    protected override void CheckMatching(IContext context)
    {
        ParseNumber(context);

        if (context.ShapeStringRepresentation[context.Position] == '.')
        {
            _sb.Append('.');
            ++context.Position;
            ParseNumber(context);

            if (_sb[_sb.Length - 1] == '.')
            {
                throw new InvalidCharacterExeption(
                    context.ShapeStringRepresentation,
                    context.Position, "`digit`");
            }
        }
    }

    public string NumberStringRepresentation => _sb.ToString();

    protected abstract override void ChangeState(IContext context);

    private void ParseNumber(IContext context)
    {
        if (context.Position >= context.ShapeStringRepresentation.Length)
        {
            throw new InvalidCharacterExeption(
                context.ShapeStringRepresentation,
                context.Position, "`digit` or \'.\'");
        }

        if (context.ShapeStringRepresentation[context.Position] == '-')
        {
            _sb.Append(context.ShapeStringRepresentation[context.Position]);
            ++context.Position;
        }

        while (char.IsDigit(context.ShapeStringRepresentation[context.Position]))
        {
            if (context.Position >= context.ShapeStringRepresentation.Length)
            {
                throw new InvalidCharacterExeption(
                    context.ShapeStringRepresentation,
                    context.Position, "`digit` or \'.\'");
            }

            _sb.Append(context.ShapeStringRepresentation[context.Position]);
            ++context.Position;
        }
    }

    private StringBuilder _sb = new StringBuilder();
}