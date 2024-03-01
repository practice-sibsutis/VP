using ApplicationWithFactoryMethod.Models;
using ApplicationWithFactoryMethod.Models.XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyExample.Models
{
    public class ProxyLoaderFactory : ILoaderFactory
    {
        public IPersonLoader CreateLoader()
        {
            return new ProxyXMLLoader(new XMLLoader());
        }

        public bool IsMatch(string path)
        {
            return ".xml".Equals(Path.GetExtension(path));
        }
    }
}
