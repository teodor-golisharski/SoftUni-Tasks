using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public List<Renovator> Renovators { get; set; }
        public int Count => this.Renovators.Count;
        public string AddRenovator(Renovator renovator)
        {
            if (Renovators.Count == NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            Renovators.Add(renovator);

            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            foreach (var item in Renovators)
            {
                if (item.Name == name)
                {
                    Renovators.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = 0;
            foreach (var item in Renovators)
            {
                if (item.Type == type)
                {
                    count++;
                }
            }
            Renovators.RemoveAll(x => x.Type == type);
            return count;
        }
        public Renovator HireRenovator(string name)
        {
            var target = Renovators.FirstOrDefault(x => x.Name == name);
            if (target == null)
            {
                return null;
            }
            Renovators.FirstOrDefault(x => x.Name == name).Hired = true;
            return target;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return Renovators.Where(r => r.Days >= days).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (Renovator item in Renovators.Where(x => x.Hired == false))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
