using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationWithFactoryMethod.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string University { get; set; }
        public Person(string name, int age, string university)
        {
            Name = name;
            Age = age;
            University = university;
        }
    }
}
