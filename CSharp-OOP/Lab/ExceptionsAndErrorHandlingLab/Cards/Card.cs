using System;
using System.Collections.Generic;
using System.Text;

namespace Cards
{
    public class Card
    {
        private static List<string> Faces = new List<string>() { "2", "3", "4", "5", "5", "7", "8", "9", "10", "J", "Q", "K", "A" };

        private static List<string> Suits = new List<string>() { "S", "H", "D", "C" };
        public Card(string face, string suit)
        {
            this.Face = face;

            this.Suit = suit;
        }

        private string face;
        private string suit;

        public string Face
        {
            get { return face; }
            set
            {
                if (!Faces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;
            }
        }
        public string Suit
        {
            get { return suit; }
            set
            {
                if (!Suits.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                suit = value;
            }
        }

        public override string ToString()
        {
            string temp = "";
            switch (Suit)
            {
                case "S": temp = "\u2660"; break;
                case "H": temp = "\u2665"; break;
                case "D": temp = "\u2666"; break;
                case "C": temp = "\u2663"; break;
            }
            return $"[{Face}{temp}]";
        }
    }
}
