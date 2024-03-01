using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationWithFactoryMethod.Models.JSON
{
    public class JSONLoaderFactory : ILoaderFactory
    {
        public IPersonLoader CreateLoader()
        {
            return new JSONLoader();
        }

        public bool IsMatch(string path)
        {
            return ".json".Equals(Path.GetExtension(path));
        }
    }
}
