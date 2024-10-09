using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
		public Car(string make, string model, int horsePower, string registrationNumber)
		{
			this.Make = make;
			this.Model = model;
			this.HorsePower = horsePower;
			this.RegistrationNumber = registrationNumber;
		}

		//Make:
		private string make;
		public string Make
		{
			get { return make; }
			set { make = value; }
		}

		//Model:
		private string model;
		public string Model
		{
			get { return model; }
			set { model = value; }
		}
		
		//Horse Power:
		private int horsePower;
		public int HorsePower
		{
			get { return horsePower; }
			set { horsePower = value; }
		}

		//Registration Number:
		private string registrationNumber;
		public string RegistrationNumber
		{
			get { return registrationNumber; }
			set { registrationNumber = value; }
		}

		public override string ToString()
		{
			return $"Make: {make}{Environment.NewLine}" +
                $"Model: {model}{Environment.NewLine}" +
                $"HorsePower: {horsePower}{Environment.NewLine}" +
                $"RegistrationNumber: {registrationNumber}";
		}
	}
}
