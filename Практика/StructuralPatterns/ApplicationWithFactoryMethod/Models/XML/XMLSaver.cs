using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ApplicationWithFactoryMethod.Models.XML
{
    public class XMLSaver : IPersonSaver
    {

        public void Save(IEnumerable<Person> people, string path)
        {
            XDocument xDocument = new XDocument();

            XElement xElementPeople = new XElement("people");

            foreach (Person person in people)
            {
                XElement xElementPerson = new XElement("person");
                XAttribute xAttributePersonName = new XAttribute("name", person.Name);
                XElement xElementPersonAge = new XElement("age", person.Age);
                XElement xElementPersonUniversity = new XElement("university", person.University);

                xElementPerson.Add(xAttributePersonName);
                xElementPerson.Add(xElementPersonAge);
                xElementPerson.Add(xElementPersonUniversity);

                xElementPeople.Add(xElementPerson);
            }

            xDocument.Add(xElementPeople);
            xDocument.Save(path);
        }
    }
}
