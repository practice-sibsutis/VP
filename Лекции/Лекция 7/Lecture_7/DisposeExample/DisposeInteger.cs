namespace DisposeExample;

public class DisposeInteger : IDisposable
{
    public DisposeInteger(int value)
    {
        _value = value;
    }

    private int _value;
    public void Dispose()
    {
        Console.WriteLine($"Dispose {_value}");
    }
}