using System.Data;
using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.BaseParsers;
using ShapeLibrary.Shapes;

namespace ShapeLibrary.Parsers.WKTParsers.ShapeParsers;

public class ShapesParser : IShapeParser
{
    public ShapesParser(IEnumerable<IShapeParser> shapeParsers)
    {
        _shapeParsers = shapeParsers;
    }
    public IShape Parse(string shapeStringRepresentation)
    {
        InvalidCharacterExeption? invalidCharacterExeption = null;
        int maxPosition = -1;

        foreach (IShapeParser shapeParser in _shapeParsers)
        {
            try
            {
                return shapeParser.Parse(shapeStringRepresentation);
            }
            catch (InvalidCharacterExeption ex)
            {
                if (maxPosition < ex.Position)
                {
                    maxPosition = ex.Position;
                    invalidCharacterExeption = ex;
                }
            }
        }

        throw invalidCharacterExeption;
    }

    private IEnumerable<IShapeParser> _shapeParsers;
}