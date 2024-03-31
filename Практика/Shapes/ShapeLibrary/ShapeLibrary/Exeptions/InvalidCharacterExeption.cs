namespace ShapeLibrary.Exeptions;

public class InvalidCharacterExeption : Exception
{
    public InvalidCharacterExeption(string stringRepresentation, int position, string expected) : base()
    {
        _stringRepresentation = stringRepresentation;
        _position = position;
        _expected = expected;
    }

    public string StringRepresentation => _stringRepresentation;
    public int Position => _position;

    public string Expected => _expected;

    private string _stringRepresentation;
    private int _position;
    private string _expected;
}