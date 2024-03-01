using ApplicationWithFactoryMethod.Models;
using ApplicationWithFactoryMethod.Models.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterExample.Models
{
    public class XMLSaverLoaderFacctory : IPersonSaverLoaderFactory
    {
        private ISaverFactory xmlSaverFactory;
        private ILoaderFactory xmlLoaderFactory;

        public XMLSaverLoaderFacctory(
            ILoaderFactory xmlLoaderFactory,
            ISaverFactory xmlSaverFactory)
        {
            this.xmlSaverFactory = xmlSaverFactory;
            this.xmlLoaderFactory = xmlLoaderFactory;
        }

        public IPersonLoader CreateLoader()
        {
            return xmlLoaderFactory.CreateLoader();
        }

        public IPersonSaver CreateSaver()
        {
            return xmlSaverFactory.CreateSaver();
        }

        public bool IsMatch(string path)
        {
            return xmlSaverFactory.IsMatch(path) &&
                   xmlLoaderFactory.IsMatch(path);
        }
    }
}
