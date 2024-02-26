using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationWithAbstractFactory.Models
{
    public class JSONLoader : IPersonLoader
    {

        public IEnumerable<Person> Load(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                List<Person>? person = JsonSerializer.Deserialize<List<Person>>(fs);

                if(person == null)
                {
                    person = new List<Person>();
                }

                return person;
            }
        }
    }
}
