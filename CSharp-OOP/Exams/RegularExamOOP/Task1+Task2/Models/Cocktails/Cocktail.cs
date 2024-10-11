using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;


namespace ChristmasPastryShop.Models.Cocktails
{
    public enum sizes
    {
        Small, Middle, Large
    }
    public abstract class Cocktail : ICocktail
    {


        public Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
            this.Size = size;
            this.Price = price;
        }

        private string name;
        private string size;
        private double price;


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size
        {
            get { return size; }
            private set 
            {
                size = value; 
            }
        }

        public double Price
        {
            get { return price; }
            private set
            {
                price = value;

                if (Size == sizes.Small.ToString())
                {
                    
                    price /= 3;
                }
                if (Size == sizes.Middle.ToString())
                {
                   
                    price = price / 3 * 2;
                }
            }
        }
        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2} lv";
        }
    }
}
