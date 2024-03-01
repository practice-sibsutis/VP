using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationWithFactoryMethod.Models.JSON
{
    public class JSONLoader : IPersonLoader
    {
        string currentPath;
        public IEnumerable<Person> Load(string path)
        {
            currentPath = path;
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                List<Person>? person = JsonSerializer.Deserialize<List<Person>>(fs);

                if (person == null)
                {
                    person = new List<Person>();
                }

                return person;
            }
        }

        public IEnumerable<Person> ReLoad()
        {
            if (currentPath != null)
            {
                return Load(currentPath);
            }

            return new List<Person>();
        }
    }
}
