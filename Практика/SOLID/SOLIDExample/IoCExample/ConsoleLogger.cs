using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIExample
{
    public class ConsoleLogger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine($"Console log - ERROR: {message}");
        }

        public void Info(string message)
        {
            Console.WriteLine($"Console log - INFO: {message}");
        }

        public void Warning(string message)
        {
            Console.WriteLine($"Console log - Warning: {message}");
        }
    }
}
