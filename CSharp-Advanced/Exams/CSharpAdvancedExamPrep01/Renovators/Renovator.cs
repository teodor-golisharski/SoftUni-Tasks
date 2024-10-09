using System;
using System.Collections.Generic;
using System.Text;

namespace Renovators
{
    public class Renovator
    {
        public Renovator(string name, string type, double rate, int days)
        {
            Name = name;
            Type = type;
            Rate = rate;
            Days = days;
        }

        private bool hired = false;

        public string Name { get; set; }
        public string Type { get; set; }
        public double Rate { get; set; }
        public int Days { get; set; }
        public bool Hired 
        { 
            get { return hired; }
            set { hired = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {this.Name}");
            sb.AppendLine($"--Specialty: {this.Type}");
            sb.AppendLine($"--Rate per day: {this.Rate} BGN");
            return sb.ToString().TrimEnd();
        }
    }
}
