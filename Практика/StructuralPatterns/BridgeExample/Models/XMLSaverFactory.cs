using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BridgeExample.Models
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
