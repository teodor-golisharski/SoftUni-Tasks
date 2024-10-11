using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
		public Person(string name, int age)
		{
			this.Name = name;
			this.Age = age;	
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		private int age;

		public int Age
		{
			get { return age; }
			set { age = value; }
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append($"Name: {this.Name}, Age: {this.Age}");
			return sb.ToString();
		}
	}
}
