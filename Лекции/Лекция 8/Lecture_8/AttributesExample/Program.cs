// See https://aka.ms/new-console-template for more information

using AttributesExample;

TestClass test = new TestClass();
test.TestMethod();

TestAttr(test);
void TestAttr(TestClass test)
{
    var testAttr = test.GetType().GetCustomAttributes(false);
    foreach (var o in testAttr)
    {
        Console.WriteLine(o.ToString());
    }
}
