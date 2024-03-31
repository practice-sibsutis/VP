using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.WKTParsers.Contexts;

namespace ShapeLibrary.Parsers.WKTParsers.States.BaseStates;

public abstract class CharacterState : BaseState
{
    public CharacterState(char character)
    {
        _character = character;
    }

    protected override void CheckMatching(IContext context)
    {
        if (context.Position >= context.ShapeStringRepresentation.Length)
        {
            throw new InvalidCharacterExeption(
                context.ShapeStringRepresentation,
                context.Position, $"\'{_character}\'");
        }

        if (context.ShapeStringRepresentation[context.Position] != _character)
        {
            throw new InvalidCharacterExeption(
                context.ShapeStringRepresentation,
                context.Position, $"\'{_character}\'");
        }

        ++context.Position;
    }

    protected abstract override void ChangeState(IContext context);

    private char _character;
}