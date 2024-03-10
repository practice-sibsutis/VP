// See https://aka.ms/new-console-template for more information
using DisposeExample;

for (int i = 0; i < 100; i++)
{
    using (var tmp = new DisposeInteger(i))
    {
        Console.WriteLine();
    }
}

Console.ReadLine();

