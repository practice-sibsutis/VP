using ApplicationWithFactoryMethod.Models;
using ApplicationWithFactoryMethod.Models.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterExample.Models
{
    public class JSONSaverFactory : ISaverFactory
    {
        public IPersonSaver CreateSaver()
        {
            return new JSONSaver();
        }

        public bool IsMatch(string path)
        {
            return ".json".Equals(Path.GetExtension(path));
        }
    }
}
