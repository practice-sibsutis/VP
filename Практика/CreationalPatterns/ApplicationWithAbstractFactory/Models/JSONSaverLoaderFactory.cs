using Avalonia.Collections;
using Avalonia.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationWithAbstractFactory.Models
{
    internal class JSONSaverLoaderFactory : ISaverLoaderFactory
    {
        public IPersonLoader CreateLoader()
        {
            return new JSONLoader();
        }

        public IPersonSaver CreateSaver()
        {
            return new JSONSaver();
        }

        public bool IsMatch(string path)
        {
            return ".json".Equals(Path.GetExtension(path));
        }
    }
}
