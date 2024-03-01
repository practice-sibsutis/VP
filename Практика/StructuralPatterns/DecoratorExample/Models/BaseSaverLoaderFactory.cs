using ApplicationWithFactoryMethod.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample.Models
{
    public abstract class BaseSaverLoaderFactory : ILoaderFactory
    {
        ILoaderFactory loaderFactory;
        public BaseSaverLoaderFactory(ILoaderFactory loaderFactory)
        {
            this.loaderFactory = loaderFactory;
        }
        public IPersonLoader CreateLoader()
        {
            return loaderFactory.CreateLoader();
        }

        public abstract IPersonSaver CreateSaver();

        public abstract bool IsMatch(string path);
    }
}
