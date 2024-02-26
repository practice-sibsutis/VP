using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationWithAbstractFactory.Models
{
    internal class XMLSaverLoaderFactory : ISaverLoaderFactory
    {
        public IPersonLoader CreateLoader()
        {
            return new XMLLoader();
        }

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
