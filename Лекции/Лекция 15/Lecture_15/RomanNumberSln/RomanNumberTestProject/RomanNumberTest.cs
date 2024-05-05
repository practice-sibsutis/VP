namespace RomanNumberTestProject;

using System.Runtime.CompilerServices;
using RomanNumber.Models;

//xUnit https://xunit.net/
//Moq https://github.com/devlooped/moq/wiki/Quickstart
//AutoFixture https://github.com/AutoFixture/AutoFixture/wiki
public class RomanNumberTest
{
    [Fact]
    public void CompareTestPrositive()
    {
        RomanNumber rn1 = new RomanNumber(10);
        RomanNumber rn2 = new RomanNumber(10);

        int result = rn1.CompareTo(rn2);
        
        Assert.True(result == 0);
    }

    [Fact]
    public void CompareTestNegative()
    {
        RomanNumber rn1 = new RomanNumber(10);
        RomanNumber rn2 = new RomanNumber(11);

        Assert.True(rn1.CompareTo(rn2) == 0);
    }

    [Fact]
    public void CompareTestNegativeWithMessage()
    {
        RomanNumber rn1 = new RomanNumber(10);
        RomanNumber rn2 = new RomanNumber(11);

        Assert.True(rn1.CompareTo(rn2) == 0, "First number is 10, second number is 11");
    }

    [Theory]
    [InlineData(2, 1, 1)]
    [InlineData(3, 1, 2)]
    [InlineData(10, 4, 6)]
    [InlineData(15, 10, 5)]
    public void SubTestWithResultWithPrimitiveTypesParams(ushort n1, ushort n2, ushort resultNumber)
    {
        RomanNumber rn1 = new RomanNumber(n1);
        RomanNumber rn2 = new RomanNumber(n2);

        RomanNumber result = rn1 - rn2;

        Assert.True(result.CompareTo(new RomanNumber(resultNumber)) == 0);
    }

    [Theory]
    [ClassData(typeof(TestDataGenerator))]
    public void SubTestWithGeneratorParams(ushort n1, ushort n2, ushort resultNumber)
    {
        RomanNumber rn1 = new RomanNumber(n1);
        RomanNumber rn2 = new RomanNumber(n2);

        RomanNumber result = rn1 - rn2;

        Assert.True(result.CompareTo(new RomanNumber(resultNumber)) == 0);
    }
}