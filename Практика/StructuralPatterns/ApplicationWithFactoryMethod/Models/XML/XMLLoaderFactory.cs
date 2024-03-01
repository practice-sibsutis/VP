using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationWithFactoryMethod.Models.XML
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
