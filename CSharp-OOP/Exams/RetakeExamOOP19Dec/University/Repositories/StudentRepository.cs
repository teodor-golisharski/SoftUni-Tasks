using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    internal class StudentRepository : IRepository<IStudent>
    {
        public StudentRepository()
        {
            models = new List<IStudent>();
        }

        private List<IStudent> models;

        public IReadOnlyCollection<IStudent> Models { get { return models.AsReadOnly(); } }

        public void AddModel(IStudent model)
        {
            models.Add(model);
        }

        public IStudent FindById(int id)
        {
            return models.FirstOrDefault(x => x.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string firstname = name.Split(' ')[0];
            string lastname = name.Split(' ')[1];
            return models.FirstOrDefault(x => x.FirstName == firstname && x.LastName == lastname);
        }
    }
}
