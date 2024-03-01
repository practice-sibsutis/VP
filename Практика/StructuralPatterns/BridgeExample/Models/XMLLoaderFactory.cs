using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeExample.Models
{
    public class XMLLoaderFactory : ILoaderFactory
    {
        public IPersonLoader CreateLoader()
        {
            return new XMLLoader();
        }

        public bool IsMatch(string path)
        {
            return ".xml".Equals(Path.GetExtension(path));
        }
    }
}
