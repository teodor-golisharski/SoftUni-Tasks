using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
		private int age;

		public Tire(int age, double pressure)
		{
			this.age = age;
		    this.pressure = pressure;
		}
		public int Age
		{
			get { return age; }
			set { age = value; }
		}

		private double pressure;

		public double Pressure
		{
			get { return pressure; }
			set { pressure = value; }
		}


	}
}
