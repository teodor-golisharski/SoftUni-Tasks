using System;
using System.Collections.Generic;

namespace Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] cardsInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var item in cardsInput)
            {
                string[] cardArgs = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                try
                {
                    Card card = new Card(cardArgs[0], cardArgs[1]);
                    cards.Add(card);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(String.Join(" ", cards));
        }
    }
}
