using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPExample.Solution
{
    internal abstract class Bird
    {
        public virtual void Walk()
        {
            Console.WriteLine($"A {this.GetType().Name} walk");
        }
    }
}
