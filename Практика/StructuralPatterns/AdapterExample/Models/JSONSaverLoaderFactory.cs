using ApplicationWithFactoryMethod.Models;
using ApplicationWithFactoryMethod.Models.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterExample.Models
{
    public class JSONSaverLoaderFactory : IPersonSaverLoaderFactory
    {
        private ILoaderFactory jsonLoaderFactory;
        private ISaverFactory jsonSaverFactory;
        public JSONSaverLoaderFactory(
            ILoaderFactory jsonLoaderFactory,
            ISaverFactory jsonSaverFactory)
        {
            this.jsonLoaderFactory = jsonLoaderFactory;
            this.jsonSaverFactory = jsonSaverFactory;
        }

        public IPersonLoader CreateLoader()
        {
            return jsonLoaderFactory.CreateLoader();
        }

        public IPersonSaver CreateSaver()
        {
            return jsonSaverFactory.CreateSaver();
        }

        public bool IsMatch(string path)
        {
            return jsonLoaderFactory.IsMatch(path) &&
                   jsonSaverFactory.IsMatch(path);
        }
    }
}
