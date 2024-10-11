using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;

        private const double calsPerGram = 2;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string Type
        {
            get { return type; }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        private double Weight
        {
            get { return weight; }
            set
            {
                if (value < 0 || value > 50)
                {
                    throw new Exception($"{type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double TotalCalories
        {
            get { return CurrentCalories(); }
        }

        private double CurrentCalories()
        {
            double total = calsPerGram * weight;
            switch (type.ToLower())
            {
                case "meat": total *= 1.2; break;
                case "veggies": total *= 0.8; break;
                case "cheese": total *= 1.1; break;
                case "sauce": total *= 0.9; break;
            }
            return total;
        }


    }
}
