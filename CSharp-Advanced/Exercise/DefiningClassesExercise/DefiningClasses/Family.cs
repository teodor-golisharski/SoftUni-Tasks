using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            this.FamilyList = new List<Person>();
        }
        public Family(List<Person> familyList)
        {
            this.FamilyList = familyList;
        }

        private List<Person> familyList;

        public List<Person> FamilyList
        {
            get { return this.familyList; }
            set { this.familyList = value; }
        }

        public void AddMember(Person member)
        {
            familyList.Add(member);
        }
        public Person GetOldestMember()
        {
            int max = int.MinValue;

            Person person = new Person();

            foreach (var item in familyList)
            {
                if (item.Age > max)
                {
                    max = item.Age;
                    person = item;
                }
            }
            return person;
        }
        public void OpinionPoll()
        {
            foreach (Person item in familyList.OrderBy(x => x.Name))
            {
                if (item.Age > 30)
                {
                    Console.WriteLine($"{item.Name} - {item.Age}");
                }
            }
        }
    }
}
