using ApplicationWithFactoryMethod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterExample.Models
{
    public interface ISaverFactory
    {
        IPersonSaver CreateSaver();

        bool IsMatch(string path);
    }
}
