using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCompetition.Models
{
    public class EconomicalSubject : Subject
    {
        private const double subjectRate = 1;
        public EconomicalSubject(int subjectId, string subjectName) : base(subjectId, subjectName, subjectRate)
        {
        }
    }
}
