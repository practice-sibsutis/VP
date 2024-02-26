using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationWithSimpleFactory.Models
{
    public interface ILoaderFactory
    {
        IPersonLoader CreateLoader(string path);
    }
}
