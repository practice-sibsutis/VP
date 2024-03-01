using ApplicationWithFactoryMethod.Models.JSON;
using ApplicationWithFactoryMethod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationWithFactoryMethod.Models.XML;
using System.IO;

namespace AdapterExample.Models
{
    public class XMLSaverFactory : ISaverFactory
    {
        public IPersonSaver CreateSaver()
        {
            return new XMLSaver();
        }

        public bool IsMatch(string path)
        {
            return ".xml".Equals(Path.GetExtension(path));
        }
    }
}
