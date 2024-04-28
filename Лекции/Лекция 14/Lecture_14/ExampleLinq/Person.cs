using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleLinq
{
    internal class Person : IEquatable<Person>, IComparable<Person>
    {
        public string Name { get; set; }

        public int CompareTo(Person? other)
        {
            return Name.CompareTo(other.Name);
        }

        public bool Equals(Person? other)
        {
            return other.Name.Equals(Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }
}
