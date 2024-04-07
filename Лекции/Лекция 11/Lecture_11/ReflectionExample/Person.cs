namespace ReflectionExample;

[TestClass]
public class Person
{
    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} {Age}";
    }

    [TestClass("Name")]
    public string FirstName
    {
        get => _firstName;
        set => _firstName = value;
    }

    public string LastName
    {
        get => _lastName;
        set => _lastName = value;
    }

    [TestClass(Param2 = "Age")]
    public int Age
    {
        get => _age;
        set => _age = value;
    }

    private string _firstName;
    private string _lastName;
    private int _age;
}