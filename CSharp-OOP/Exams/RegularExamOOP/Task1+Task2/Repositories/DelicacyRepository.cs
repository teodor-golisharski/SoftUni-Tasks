﻿using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        public DelicacyRepository()
        {
            models = new List<IDelicacy>();
        }
        private List<IDelicacy> models;

        public IReadOnlyCollection<IDelicacy> Models => models.AsReadOnly();

        public void AddModel(IDelicacy model)
        {
            models.Add(model);
        }
    }
}
