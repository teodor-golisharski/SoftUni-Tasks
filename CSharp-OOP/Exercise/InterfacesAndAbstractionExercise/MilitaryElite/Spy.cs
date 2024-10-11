using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class Spy : ISpy, ISoldier
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CodeNumber = codeNumber;
        }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CodeNumber { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}{Environment.NewLine}" +
                $"Code Number: {CodeNumber}";
        }
    }
}
