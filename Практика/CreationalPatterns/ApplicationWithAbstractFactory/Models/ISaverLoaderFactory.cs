using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationWithAbstractFactory.Models
{
    public interface ISaverLoaderFactory
    {
        IPersonLoader CreateLoader();
        IPersonSaver CreateSaver();
        bool IsMatch(string path);
    }
}
