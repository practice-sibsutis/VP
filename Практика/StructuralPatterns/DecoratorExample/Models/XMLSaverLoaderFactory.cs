using ApplicationWithFactoryMethod.Models;
using ApplicationWithFactoryMethod.Models.XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample.Models
{
    public class XMLSaverLoaderFactory : BaseSaverLoaderFactory
    {
        public XMLSaverLoaderFactory(XMLLoaderFactory xmlLoaderFactory)
            : base(xmlLoaderFactory) { }
        public override IPersonSaver CreateSaver()
        {
            return new XMLSaver();
        }

        public override bool IsMatch(string path)
        {
            return ".xml".Equals(Path.GetExtension(path));
        }
    }
}
