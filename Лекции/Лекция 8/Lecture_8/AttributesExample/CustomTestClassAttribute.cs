using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesExample
{
    public class CustomTestClassAttribute : Attribute
    {
        public CustomTestClassAttribute(string testString)
        {
            TestString = testString;
            Console.WriteLine(testString);
        }
        public string TestString { get; }
    }
}
