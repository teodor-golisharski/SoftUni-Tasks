using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        public VesselRepository()
        {
            models = new List<IVessel>();
        }

        private List<IVessel> models;

        public IReadOnlyCollection<IVessel> Models => models.AsReadOnly();

        public void Add(IVessel model)
        {
            models.Add(model);
        }

        public IVessel FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IVessel model)
        {
            if (models.FirstOrDefault(x => x.Name == model.Name) == null)
            {
                return false;
            }
            return true;
        }
    }
}
