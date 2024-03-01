using ApplicationWithFactoryMethod.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyExample.Models
{
    public class ProxyXMLLoader : IPersonLoader
    {
        IPersonLoader xmlLoader;
        public ProxyXMLLoader(IPersonLoader xmlLoader)
        {
            this.xmlLoader = xmlLoader;
        }
        public IEnumerable<Person> Load(string path)
        {
            Debug.WriteLine($"Start load data from {path}");

            var people = xmlLoader.Load(path);

            Debug.WriteLine($"End load data from {path}");

            return people;
        }

        public IEnumerable<Person> ReLoad()
        {
            return xmlLoader.ReLoad();
        }
    }
}
