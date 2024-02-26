using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationWithSimpleFactory.Models
{
    public class SimpleLoaderFactory : ILoaderFactory
    {
        public IPersonLoader CreateLoader(string path)
        {
            string extention = Path.GetExtension(path);

            switch (extention)
            {
                case ".xml":
                    return new XMLLoader();

                case ".json":
                    return new JSONLoader();

                default:
                    return null;
            }
        }
    }
}
