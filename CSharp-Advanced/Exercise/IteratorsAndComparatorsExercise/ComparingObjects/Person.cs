using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name != other.Name)
            {
                return this.Name.CompareTo(other.Name);
            }
            else if (this.Age != other.Age)
            {
                return this.Age.CompareTo(other.Age);
            }

            return this.Town.CompareTo(other.Town);
            
        }
    }
}