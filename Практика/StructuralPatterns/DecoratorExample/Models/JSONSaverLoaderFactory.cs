using ApplicationWithFactoryMethod.Models;
using ApplicationWithFactoryMethod.Models.JSON;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample.Models
{
    public class JSONSaverLoaderFactory : BaseSaverLoaderFactory
    {
        public JSONSaverLoaderFactory(JSONLoaderFactory jsonLoaderFactory)
            : base(jsonLoaderFactory) { }
        public override IPersonSaver CreateSaver()
        {
            return new JSONSaver();
        }

        public override bool IsMatch(string path)
        {
            return ".json".Equals(Path.GetExtension(path));
        }
    }
}
