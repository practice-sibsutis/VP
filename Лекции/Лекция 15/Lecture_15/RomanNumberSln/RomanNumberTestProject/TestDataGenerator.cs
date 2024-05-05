namespace RomanNumberTestProject;
 
public class TestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        for(int i = 0; i < 10; ++i)
        {
            ushort n1 = (ushort)_rnd.Next(2, 3999);
            ushort n2 = (ushort)_rnd.Next(1, n1 - 1);
            yield return new object[]{n1, n2, (ushort)(n1 - n2)};
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

    private Random _rnd = new Random();
}
