using System;
using System.Text;
using System.Linq;

namespace DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder digit = new StringBuilder();
            StringBuilder letter = new StringBuilder();
            StringBuilder character = new StringBuilder();
            foreach (var item in text)
            {
                if (char.IsDigit(item))
                {
                    digit.Append(item);
                }
                else if(char.IsLetter(item))
                {
                    letter.Append(item);
                }
                else
                {
                    character.Append(item);
                }
            }
            Console.WriteLine(digit);
            Console.WriteLine(letter);
            Console.WriteLine(character);
        }
    }
}
