using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;
        
        private const double calsPerGram = 2;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        
        private string FlourType 
        {
            set 
            { 
                if(value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }
                flourType = value;
            } 
        }
        private string BakingTechnique 
        {
            get { return bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new Exception("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }

        private double Weight
        {
            get { return weight; }
            set
            {
                if (value < 0 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
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
            switch (flourType.ToLower())
            {
                case "white": total *= 1.5; break;
                case "wholegrain": total *= 1; break;
            }
            switch (bakingTechnique.ToLower())
            {
                case "crispy": total *= 0.9; break;
                case "chewy": total *= 1.1; break;
                case "homemade": total *= 1; break;
            }
            return total;
        }
    }
}
