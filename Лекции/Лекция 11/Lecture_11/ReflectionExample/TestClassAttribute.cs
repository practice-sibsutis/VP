namespace ReflectionExample;

public class TestClassAttribute : Attribute
{
    public TestClassAttribute()
    { }

    public TestClassAttribute(string param1)
    {
        _param1 = param1;
    }

    public string Param1 => _param1;
    public string Param2 { get; set; }
    
    private string _param1;
}