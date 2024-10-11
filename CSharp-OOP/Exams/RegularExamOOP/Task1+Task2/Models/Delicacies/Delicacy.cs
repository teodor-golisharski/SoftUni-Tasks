using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {

        public Delicacy(string delicacyName, double price)
        {
            this.Name = delicacyName;
            this.Price = price;
        }

        private string delicacyName;
        private double price;

        public string Name
        {
            get { return delicacyName; }
            private set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NameNullOrWhitespace);
                }
                delicacyName = value;
            }
        }

        public double Price
        {
            get { return price; }
            private set { price = value; }
        }

        public override string ToString()
        {
            return $"{Name} - {Price:f2} lv";
        }
    }
}
