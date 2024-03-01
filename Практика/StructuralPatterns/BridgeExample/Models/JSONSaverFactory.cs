using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeExample.Models
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
