using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public enum categories
    {
        Technical, Economical, Humanity
    }
    public class University : IUniversity
    {
        public University(int universityId, string universityName, string category, int capacity,
ICollection<int> requiredSubjects
)
        {
            this.Id = universityId;
            this.Name = universityName;
            this.Category = category;
            this.Capacity = capacity;
            this.requiredSubjects = new List<int>();
            this.requiredSubjects = requiredSubjects;
        }
        private int capacity;
        private string name;
        private string category;
        private ICollection<int> requiredSubjects;
        
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


        public string Category
        {
            get { return category; }
            private set
            {
                if(value!=categories.Technical.ToString() && value != categories.Economical.ToString() && value != categories.Humanity.ToString())
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));
                }
                category = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set 
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);
                }
                capacity = value; 
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects
        {
            get { return this.requiredSubjects.ToList().AsReadOnly(); }
        }
    }
}
