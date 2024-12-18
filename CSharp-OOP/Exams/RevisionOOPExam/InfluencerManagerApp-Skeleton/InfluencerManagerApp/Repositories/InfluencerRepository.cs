﻿using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InfluencerManagerApp.Repositories
{
    public class InfluencerRepository : IRepository<IInfluencer>
    {
        private readonly List<IInfluencer> models;

        public InfluencerRepository()
        {
            models = new List<IInfluencer>();
        }

        public IReadOnlyCollection<IInfluencer> Models => models;

        public void AddModel(IInfluencer model)
        {
            models.Add(model);
        }

        public IInfluencer FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Username == name)!;
        }

        public bool RemoveModel(IInfluencer model)
        { 
            return models.Remove(model);
        }
    }
}
