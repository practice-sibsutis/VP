using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributesExample
{
    [CustomTestClass("Test string")]
    public class TestClass
    {
        [CustomTestClass("Method TestMethod")]
        public void TestMethod()
        {}
    }
}
