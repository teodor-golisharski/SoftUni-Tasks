using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DefiningClasses
{
	public class Engine
	{
		private string model;
		private int power;
		private int displacement;
		private string efficiency;

		public Engine(string model, int power)
		{
            this.model = model;
            this.power = power;
			this.displacement = -1;
			this.efficiency = "n/a";
        }
		public Engine(string model, int power, int displacement) : this(model, power)
		{
			this.displacement = displacement;
		}
		public Engine(string model, int power, string efficiency) : this(model, power)	
		{
			this.efficiency = efficiency;
		}
        public Engine(string model, int power, int displacement, string efficiency) : this(model, power, displacement)
        {
			this.efficiency = efficiency;
        }
        public string Model
		{
			get { return model; }
			set { model = value; }
		}
		public int Power
		{
			get { return power; }
			set { power = value; }
		}
		public int Displacement
		{
			get { return displacement; }
			set { displacement = value; }
		}
		public string Efficiency
		{
			get { return efficiency; }
			set { efficiency = value; }
		}
	}
}
