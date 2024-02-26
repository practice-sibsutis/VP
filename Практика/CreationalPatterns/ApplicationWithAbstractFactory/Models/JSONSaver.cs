using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationWithAbstractFactory.Models
{
    public class JSONSaver : IPersonSaver
    {
        public void Save(IEnumerable<Person> people, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, people,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });
            }
        }
    }
}
