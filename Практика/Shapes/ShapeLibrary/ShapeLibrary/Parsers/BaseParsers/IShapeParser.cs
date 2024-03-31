using ShapeLibrary.Shapes;

namespace ShapeLibrary.Parsers.BaseParsers;

public interface IShapeParser
{
    IShape Parse(string shapeStringRepresentation);
}