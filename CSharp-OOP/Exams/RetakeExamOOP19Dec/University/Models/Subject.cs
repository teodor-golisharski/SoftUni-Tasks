using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {
        public Subject(int subjectId, string subjectName, double subjectRate)
        {
            this.Id = subjectId;
            this.Name = subjectName;
            this.Rate = subjectRate;
        }

        private string name;
        private int id = 1;

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }
        public double Rate { get; private set; }
    }
}
