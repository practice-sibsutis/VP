using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONExample.model
{
    public class Company
    {
        public string? Name { get; set; }
        public string? CatchPhrase { get; set; }
        public string? Bs { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} CatchPhrase: {CatchPhrase} Bs: {Bs}";
        }
    }
}
