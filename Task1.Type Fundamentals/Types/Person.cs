using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public class Person: IEquatable<Person>
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Equals(Person other)
        {
            if (other == null)
                return false;
            return other.FirstName == FirstName && other.LastName == LastName;
        }
    }
}
