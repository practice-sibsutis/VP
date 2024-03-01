using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApplicationWithFactoryMethod.Models.XML
{
    public class XMLLoader : IPersonLoader
    {
        private string currentPath;

        public IEnumerable<Person> ReLoad()
        {
            if (currentPath != null)
            {
                return Load(currentPath);
            }
            else
            {
                return new List<Person>();
            }
        }
        public IEnumerable<Person> Load(string path)
        {
            currentPath = path;
            XDocument xDocument = XDocument.Load(path);
            IEnumerable<Person>? persons = xDocument.Element("people")?
                    .Elements("person")
                    .Where(person =>
                    {
                        var personName = person.Attribute("name");
                        var university = person.Element("university");
                        var personAge = person.Element("age");


                        if (personName != null &&
                           personAge != null &&
                           university != null)
                        {
                            if (int.TryParse(personAge.Value, out int _) == true)
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                    )
                    .Select(
                        person =>
                        {
                            var personName = person.Attribute("name");
                            var university = person.Element("university");
                            var personAge = person.Element("age");


                            return new Person(personName.Value,
                                int.Parse(personAge.Value),
                                university.Value);
                        }
                    );

            if (persons == null)
            {
                return new List<Person>();
            }

            return persons;
        }
    }
}
