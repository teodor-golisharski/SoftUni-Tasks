using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;


        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        //Status: Done
        public string AddStudent(string firstName, string lastName)
        {
            IStudent student = students.FindByName($"{firstName} {lastName}");

            if (student != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            student = new Student(1 + students.Models.Count, firstName, lastName);
            students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        //Status: Done 
        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject = subjects.FindByName(subjectName);

            if (subjectType != "TechnicalSubject" && subjectType != "EconomicalSubject" && subjectType != "HumanitySubject")
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            if (subject != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }
            if (subjectType == "TechnicalSubject")
            {
                subject = new TechnicalSubject(1 + subjects.Models.Count, subjectName);
            }
            else if (subjectType == "EconomicalSubject")
            {
                subject = new EconomicalSubject(1 + subjects.Models.Count, subjectName);
            }
            else if (subjectType == "HumanitySubject")
            {
                subject = new HumanitySubject(1 + subjects.Models.Count, subjectName);
            }
            subjects.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        //Status: Done
        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            IUniversity university = universities.FindByName(universityName);

            if (university != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            ICollection<int> collection = new List<int>();
            ISubject sub; 
            foreach (var item in requiredSubjects)
            {
                sub = subjects.FindByName(item);
                collection.Add(sub.Id);
            }

            university = new University(1 + universities.Models.Count, universityName, category, capacity, collection);
            universities.AddModel(university);
            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        //Status: Done
        public string ApplyToUniversity(string studentName, string universityName)
        {
            IStudent student = students.FindByName(studentName);
            IUniversity university = universities.FindByName(universityName);


            string first = studentName.Split(" ")[0];
            string last = studentName.Split(" ")[1];

            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, first, last);
            }
            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            foreach (var exam in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(exam))
                {
                    return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
                }
            }
            if (student.University == university)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, student.FirstName, student.LastName, universityName);
            }
            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName, universityName);

        }
        //Status: Done
        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);

            if (student == null)
            {
                return OutputMessages.InvalidStudentId;
            }
            if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }
            if (student.CoveredExams.Any(x => x == subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        //Status: 
        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);

            StringBuilder sb = new StringBuilder();

            int countIn = students.Models.Count(x => x.University == university);

            sb.AppendLine($"*** {university.Name} ***");

            sb.AppendLine($"Profile: {university.Category}");

            sb.AppendLine($"Students admitted: {countIn}");

            sb.AppendLine($"University vacancy: {university.Capacity - countIn}");
            
            return sb.ToString().TrimEnd();
        }
    }
}
