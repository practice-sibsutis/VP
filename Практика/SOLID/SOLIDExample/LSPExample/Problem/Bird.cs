using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPExample.Problem
{
    public class Bird
    {
        public virtual void Walk()
        {
            Console.WriteLine($"A {this.GetType().Name} walk");
        }

        public virtual void Fly()
        {
            Console.WriteLine($"A {this.GetType().Name} fly");
        }
    }
}
