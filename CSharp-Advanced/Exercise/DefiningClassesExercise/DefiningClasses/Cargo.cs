using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Cargo
    {
		private string type;

		public Cargo(string type, int weight)
		{
			this.Type = type;
			this.Weight = weight;
		}
		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		private int weight;

		public int Weight
		{
			get { return weight; }
			set { weight = value; }
		}


	}
}
