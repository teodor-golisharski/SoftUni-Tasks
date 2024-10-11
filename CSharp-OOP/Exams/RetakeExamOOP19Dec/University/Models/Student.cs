using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        public Student(int studentId, string firstName, string lastName)
        {
            this.Id= studentId;
            this.FirstName= firstName;
            this.LastName= lastName;
            coveredExams = new List<int>();
        }


        private string firstName;
        private string lastName;
        private List<int> coveredExams;

        private int id = 1;

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams
        {
            get { return this.coveredExams.AsReadOnly(); }
        } 

        public IUniversity University { get; private set; }

        public void CoverExam(ISubject subject)
        {
            coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            University = university;
        }
    }
}
