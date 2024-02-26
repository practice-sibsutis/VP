using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationWithAbstractFactory.Models
{
    public interface IPersonLoader
    {
        IEnumerable<Person> Load(string path);
    }
}
